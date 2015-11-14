#include <stdio.h>
#include <stdlib.h>
#include <errno.h>
#include <string.h>

#define BUFFER_SIZE 64

void kill(const char *);

void kill(const char *msg)
{
    if (errno)
        perror(msg);
    else 
        fprintf(stderr, "ERROR: %s", msg);
    
    exit(1);
}

const char *get_filename_ext(const char *filename) {
    const char *dot = strrchr(filename, '.');
    if(!dot || dot == filename) return "";
    return dot + 1;
}

int main(int argc, char **argv) 
{
    if (argc < 3)
        kill("Usage: [<src-file-1> <src-file-2> …]");
    
    int i;

    char mergedFileName[50];
    sprintf(mergedFileName, "merged.%s", get_filename_ext(argv[1]));
    FILE *mergedFile = fopen(mergedFileName, "w");
    if (!mergedFile)
        kill(NULL);

    for (i = 1; i < argc; i++)
    {
        const char *srcFileName = argv[i];

        FILE *srcFile = fopen(srcFileName, "r");
        if (!srcFile)
        {
            char error[50];
            sprintf(error, "%s: No such file or directory", argv[i]);
            kill(error);
        }

        char buffer[BUFFER_SIZE];
        while (!feof(srcFile))
        {
            int readBytes = fread(buffer, 1, BUFFER_SIZE, srcFile);
            
            if (ferror(srcFile))
                kill("Error reading from source");

            char sign[4];

            memcpy(sign, buffer + readBytes - 4, 4);
            sign[4] = '\0';

            if (sign[0] == '3' && sign[1] == '4' && sign[2] == '5' && sign[3] == '6')
            {
                fwrite(buffer, 1, readBytes - 4, mergedFile);
            }
            else if (sign[0] == '!' && sign[1] == '"' && sign[2] == '#' && sign[3] == '$')
            {
                size_t firstPartSize = (readBytes - 4) / 2;
                fwrite(buffer, 1, firstPartSize, mergedFile);
            }
        }

        fclose(srcFile);
    }

    fclose(mergedFile);
    
    return 0;
}
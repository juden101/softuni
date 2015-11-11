char *str_to_lower(char *);
char *str_join(char, size_t);
char *str_replace_all(const char *, const char *, const char *);
char *str_concat(char *source, char *dest, size_t size);
int word_count(char *input, char delimiter);
size_t str_length(char *);
int str_search(char *src, char *substr);
char *str_substr(char *src, int position, int length);
using System;

public interface IProject
{
    string ProjectNam { get; set; }
    DateTime ProjectStart { get; set; }
    string Details { get; set; }
    ProjectState State { get; set; }

    void CloseProject();
}
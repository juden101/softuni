﻿using System;
using System.Collections.Generic;

namespace BugTracker.Data.Models
{
    public class Bug
    {
        private ICollection<Comment> comments;

        public Bug()
        {
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public BugStatus Status { get; set; }

        public virtual User Author { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}

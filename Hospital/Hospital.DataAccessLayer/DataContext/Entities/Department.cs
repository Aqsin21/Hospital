﻿namespace Hospital.DataAccessLayer.DataContext.Entities
{
    public class Department:BaseEntity
    {
        public required String Name { get; set; }
        public required String Description { get; set; }

    }
}

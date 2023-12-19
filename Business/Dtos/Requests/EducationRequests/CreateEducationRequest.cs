﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests.EducationRequests
{
    public class CreateEducationRequest
    {
        public int UserId { get; set; }
        public int EducationDegreeId { get; set; }
        public int SchoolNameId { get; set; }
        public string Department { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Domain.Entities
{
    public class Exam
    {
        public int? ExamId { get; set; }
        public string? Name { get; set; }
        public int? AnalysisId { get; set; }
        public int? State { get; set; }
        public DateTime? AuditCreateDate { get; set; }
    }
}

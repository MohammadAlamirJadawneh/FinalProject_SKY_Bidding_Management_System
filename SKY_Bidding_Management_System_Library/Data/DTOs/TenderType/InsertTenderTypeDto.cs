﻿using System.ComponentModel.DataAnnotations;

namespace SKY_Bidding_Management_System_Library.Data.DTOs.TenderType
{
    public class InsertTenderTypeDto
    {
        [Required]
        public string TenderTypeName { get; set; }
    }
}

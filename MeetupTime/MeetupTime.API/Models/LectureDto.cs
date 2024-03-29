﻿using System.ComponentModel.DataAnnotations;

namespace MeetupTime.API.Models;

public class LectureDto
{
    [Required]
    [MinLength(5)]
    public string Author { get; set; }

    [Required]
    [MinLength(5)]
    public string Topic { get; set; }

    public string Description { get; set; }
}

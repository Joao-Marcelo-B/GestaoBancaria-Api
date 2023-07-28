﻿using System.ComponentModel.DataAnnotations;

namespace GestaoBancaria.Models;

public class Cliente
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
}

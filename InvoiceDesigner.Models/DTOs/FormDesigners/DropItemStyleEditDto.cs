﻿using System.ComponentModel.DataAnnotations;

namespace InvoiceDesigner.Domain.Shared.DTOs.FormDesigners
{
	public class DropItemStyleEditDto
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; } = string.Empty;

		[Required]
		public string Value { get; set; } = string.Empty;

		public int DropItemId { get; set; }
	}
}

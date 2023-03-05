﻿namespace SLS.PM.Data;

internal static partial class CreateModel
{

	internal static void PostalAddressType(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<PostalAddressType>(entity =>
		{
			entity.ToTable("PostalAddressType", "PM");

			entity.HasComment("Lookup values representing phone number types used by Glennis.");

			entity.HasIndex(e => e.ExternalId, "unqPostalAddressType_ExternalId")
					.IsUnique()
					.HasFilter("([ExternalId] IS NOT NULL)");

			entity.Property(e => e.PostalAddressTypeId).HasComment("Identifier of the phone number type.");

			entity.Property(e => e.ExternalId)
					.HasMaxLength(100)
					.HasComment("The operator identifier for the phone number type.");

			entity.Property(e => e.IsDefault).HasComment("Flag indicating whether the phone number type is the default phone number type.");

			entity.Property(e => e.PostalAddressTypeName)
					.HasMaxLength(100)
					.IsUnicode(false)
					.HasComment("Name of the phone number type.");

			entity.Property(e => e.RowStatusId)
					.HasDefaultValueSql("((1))")
					.HasComment("Identifier of the status for the row (i.e. enabled, disabled, etc.).");

			entity.Property(e => e.SortOrder).HasComment("The sorting order of the phone number type.");
		});
	}

}
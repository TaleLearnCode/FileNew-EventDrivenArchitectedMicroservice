﻿namespace SLS.CM.Domain;

/// <summary>
/// Represents a community run by the tenant.
/// </summary>
public partial class Community
{
	public Community()
	{
		ResidentCommunities = new HashSet<ResidentCommunity>();
		Rooms = new HashSet<Room>();
	}

	/// <summary>
	/// The identifier of the community record.
	/// </summary>
	public int CommunityId { get; set; }
	/// <summary>
	/// The tenant&apos;s number (identifier) for the community.
	/// </summary>
	public string CommunityNumber { get; set; } = null!;
	/// <summary>
	/// The name of the community.
	/// </summary>
	public string CommunityName { get; set; } = null!;
	/// <summary>
	/// URL of the digital asset that serves as the profile image for the community.
	/// </summary>
	public string? ProfileImageUrl { get; set; }
	public int CommunityStatusId { get; set; }
	/// <summary>
	/// Identifier of the community record status (i.e. enabled, disabled, etc).
	/// </summary>
	public int RowStatusId { get; set; }

	public virtual CommunityStatus CommunityStatus { get; set; } = null!;
	public virtual ICollection<ResidentCommunity> ResidentCommunities { get; set; }
	public virtual ICollection<Room> Rooms { get; set; }
}
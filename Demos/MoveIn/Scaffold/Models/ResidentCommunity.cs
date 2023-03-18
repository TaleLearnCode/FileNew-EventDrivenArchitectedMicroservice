﻿using System;
using System.Collections.Generic;

namespace Scaffold.Models
{
    public partial class ResidentCommunity
    {
        public ResidentCommunity()
        {
            ResidentAncillaryCares = new HashSet<ResidentAncillaryCare>();
        }

        public int ResidentCommunityId { get; set; }
        public int ResidentId { get; set; }
        public int CommunityId { get; set; }

        public virtual Community Community { get; set; } = null!;
        public virtual Resident Resident { get; set; } = null!;
        public virtual ICollection<ResidentAncillaryCare> ResidentAncillaryCares { get; set; }
    }
}
using System;

namespace apiNZWalks.Models.DTO{
     public class RegionsDTO
     {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
     }

     public class AddRegionDTO{
          public string Code { get; set; }

        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }  
     }

     public class updateRegionDTO{
      public string? Code { get; set; }
      public string? Name { get; set; }
        public string? RegionImageUrl { get; set; }  
     }
}


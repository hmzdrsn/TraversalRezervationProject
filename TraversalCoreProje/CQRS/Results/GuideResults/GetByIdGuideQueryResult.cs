﻿namespace TraversalCoreProje.CQRS.Results.GuideResults
{
    public class GetByIdGuideQueryResult
    {
        public int GuideID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}

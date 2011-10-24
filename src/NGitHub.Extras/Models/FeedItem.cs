﻿using System;
using System.ServiceModel.Syndication;
using NGitHub.Extras.Utility;

namespace NGitHub.Extras.Models {
    public class FeedItem {
        public FeedItem() {
            // For serialization
        }

        public FeedItem(SyndicationItem item) {
            Ensure.ArgumentNotNull(item, "item");

            Id = item.Id;
            User = item.Authors[0].Name;
            PublishDate = item.PublishDate.DateTime;
            Title = item.Title.Text;
            Content = ((TextSyndicationContent)item.Content).Text;
        }

        public string Id { get; set; }

        public string User { get; set; }

        public DateTime PublishDate { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}

public class CommunityData
{
    public string CommunityName { get; set; }
    public string UserNameOwner { get; set; }
    public string ? CommunityPhoto { get; set; }
    public string ? Description { get; set; }
    public string ? CommunityPhotoBackground { get; set; }
    public List<PostItem> ? PostList { get; set; }
    public int Members { get; set; }
    public bool InCommunity { get; set; }
}
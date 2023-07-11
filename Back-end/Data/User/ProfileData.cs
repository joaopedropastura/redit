public class ProfileData
{
    public string Name { get; set; }
    public string ? UserName { get; set; }
    public string ? UserPhoto { get; set; }
    public string ? UserPhotoBackground { get; set; }
    public DateTime ? BornDate { get; set; }
    public DateTime AssignDate { get; set; }
    public List<PostItem> ? PostList { get; set; }
}
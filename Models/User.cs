public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }

    public virtual string AccessInterface() => "/Home/Index";
}

public class Admin : User
{
    public override string AccessInterface() => "/Admin/Index";

}

public class Customer : User
{
    public override string AccessInterface() => "/Home/Index";
}


public class Rootobject
{
    public string modelName { get; set; }
    public string currentElementID { get; set; }
    public string currentElementName { get; set; }
    public Actions[] actions { get; set; }
    public object[] properties { get; set; }
}

public class Actions
{
    public string Action { get; set; }
}


public class FastEnemy : BaseEnemy
{
    protected override void Start()
    {
        Speed = 6f;
        MaxHits = 1;
        base.Start();
    }
}

public class FastEnemy : BaseEnemy //INHERITANCE
{
    protected override void Start() //POLYMORPHISM
    {
        Speed = 6f;
        MaxHits = 1;
        base.Start();
    }
}

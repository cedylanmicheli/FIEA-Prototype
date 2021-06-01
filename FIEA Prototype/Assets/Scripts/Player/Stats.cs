public struct Stats
{
    public int maxHealth;
    public float moveSpeed;
    public float attackSpeed;
    public float damage;
    public float scale;
    public int health;
    
    //Just in here to update the "current stats" page for use in-editor
    public void UpdateCurrentInEditor()
    {
        PlayerManager.instance.currentMaxHealth = maxHealth;
        PlayerManager.instance.currentMoveSpeed = moveSpeed;
        PlayerManager.instance.currentDamage = damage;
        PlayerManager.instance.currentAttackSpeed = attackSpeed;
        PlayerManager.instance.currentHealth = health;
        //PlayerManager.instance.player.transform.localScale = new UnityEngine.Vector3(2, 2, 2);
    }
}

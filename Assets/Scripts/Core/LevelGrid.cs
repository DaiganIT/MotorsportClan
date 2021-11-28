using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    [SerializeField] private Vector2Int gridSize;
    private Level level;
    
    private void Awake()
    {
        GenerateLevel();
    }

    [ContextMenu("Regenerate Level")]
    private void GenerateLevel()
    {
        level = new Level(gridSize.x, gridSize.y);
    }

    private void OnDrawGizmosSelected()
    {
        // draw the grid
        if (level == null) return;
        
        for(var i = 0; i < level.Count; i++)
            Gizmos.DrawWireCube(level.GetCenter(i), level.UnitVector);
    }
}
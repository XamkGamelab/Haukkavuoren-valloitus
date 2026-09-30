using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerMovement))]
public class PlayerMovementEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the normal Inspector
        DrawDefaultInspector();

        // Get the PlayerMovement component
        PlayerMovement player = (PlayerMovement)target;

        // Player sprite preview
        if (player.playerImage != null)
        {
            GUILayout.Space(10);

            GUILayout.Label("Player Sprite Preview");

            Texture2D preview = AssetPreview.GetAssetPreview(
                player.playerImage
            );

            if (preview != null)
            {
                GUILayout.Label(
                    preview,
                    GUILayout.Width(100),
                    GUILayout.Height(100)
                );
            }
        }

        // Jump sprite preview
        if (player.jumpImage != null)
        {
            GUILayout.Space(10);

            GUILayout.Label("Jump Sprite Preview");

            Texture2D preview = AssetPreview.GetAssetPreview(
                player.jumpImage
            );

            if (preview != null)
            {
                GUILayout.Label(
                    preview,
                    GUILayout.Width(100),
                    GUILayout.Height(100)
                );
            }
        }
    }
}
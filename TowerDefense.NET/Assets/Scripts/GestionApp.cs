using UnityEngine;
using System.Collections;

public static class GestionApp {
    /// <summary>
    /// définit les propriétés spécifique de mon application
    /// </summary>
    public static void SetCursorState(CursorLockMode wantedMode)
    {
        Cursor.lockState = wantedMode;
        // Hide cursor when locking
        Cursor.visible = (CursorLockMode.Locked != wantedMode);
    }
    public static void LoadScene(string NomScene)
    {
        Application.LoadLevel(NomScene);
    }
    public static void Exit()
    {
        Application.Quit();
    }

}

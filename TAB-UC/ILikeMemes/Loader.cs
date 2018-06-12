namespace ILikeMemes
{
    public class Loader
    {

        static UnityEngine.GameObject Player_ESPObject;
        static UnityEngine.GameObject object_Advanced;
        static UnityEngine.GameObject object_Menu;
        static UnityEngine.GameObject object_SpawnItem;


        public static void Load()
        {
            Player_ESPObject = new UnityEngine.GameObject();
            Player_ESPObject.AddComponent<Player_ESP>();
            UnityEngine.Object.DontDestroyOnLoad(Player_ESPObject);

            object_Advanced = new UnityEngine.GameObject();
            object_Advanced.AddComponent<Advanced>();
            UnityEngine.Object.DontDestroyOnLoad(object_Advanced);

            object_Menu = new UnityEngine.GameObject();
            object_Menu.AddComponent<Menu>();
            UnityEngine.Object.DontDestroyOnLoad(object_Menu);
        }
    }
}

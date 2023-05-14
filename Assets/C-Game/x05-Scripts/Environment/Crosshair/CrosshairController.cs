using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR

using UnityEditor;

#endif

public class CrosshairController : MonoBehaviour
{
    enum SightsType { circle, arrows, cross }
    [SerializeField] private BaseEventHandler EventHandler;
    private BaseCharacterControllerConfiguration characterConfigs;
    
    [Header("Presets:")]
    [SerializeField] SightsType sightsType;

    private Transform _sightsLeft;
    private Transform _sightsRight;

    private Transform cursorTransform;

    string variable1;
    int variable2;
    float variable3;

    bool showSights = false;

    private List<GameObject> sights = new List<GameObject>();


    private void Awake()
    {
        characterConfigs = EventHandler.CurrentCharacterConfigs;
        EventHandler.onCharacterSwitchedEvent.AddListener(OnValueChanged);
        cursorTransform = transform.root;
    }

    private void Update()
    {
        CircleSightsMod();
    }

    private void ArrowSightsMod()
    {
        Vector2 posSet1 = new Vector2(-characterConfigs.RecoilCurrent / 2 + cursorTransform.position.x, cursorTransform.position.y);
        Vector2 posSet2 = new Vector2(+characterConfigs.RecoilCurrent / 2 + cursorTransform.position.x, cursorTransform.position.y);

        _sightsLeft.position = posSet1;
        _sightsRight.position = posSet2;
    }

    private void CircleSightsMod()
    {
        this.transform.localScale = new Vector2(characterConfigs.RecoilCurrent , characterConfigs.RecoilCurrent);
    }

    private void OnValueChanged(BaseCharacterControllerConfiguration value)
    {
        characterConfigs = value;
    }

    #region Editor
#if UNITY_EDITOR

    [CustomEditor(typeof(CrosshairController))]
    public class CrosshairEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            CrosshairController crosshair = (CrosshairController)target;

            DrawDetails(crosshair);
            DrawLists(crosshair);
        }

        private static void DrawDetails(CrosshairController crosshair)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Details:");
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Var1", GUILayout.MaxWidth(50));
            crosshair.variable1 = EditorGUILayout.TextField(crosshair.variable1);
            EditorGUILayout.LabelField("Var2", GUILayout.MaxWidth(50));
            crosshair.variable2 = EditorGUILayout.IntField(crosshair.variable2);
            EditorGUILayout.LabelField("Var3", GUILayout.MaxWidth(50));
            crosshair.variable3 = EditorGUILayout.FloatField(crosshair.variable3);
            
            EditorGUILayout.EndHorizontal();
        }

        private static void DrawLists(CrosshairController crosshair)
        {
            if (crosshair.sightsType == SightsType.arrows)
            {
                EditorGUILayout.Space();
                crosshair.showSights = EditorGUILayout.Foldout(crosshair.showSights, "Sights", true);

                if (crosshair.showSights)
                {
                    EditorGUI.indentLevel++;

                    List<GameObject> list = crosshair.sights;

                    int size = Mathf.Max(0, EditorGUILayout.IntField("Size", list.Count));

                    while (size > list.Count)
                    {
                        list.Add(null);
                    }

                    while (size < list.Count)
                    {
                        list.RemoveAt(list.Count - 1);
                    }

                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i] = EditorGUILayout.ObjectField("Element " + i, list[i], typeof(GameObject), true) as GameObject; 
                    }

                    EditorGUI.indentLevel--;
                }
            }
        }
    }

#endif
    #endregion
}

using KSP.UI.Screens.DebugToolbar.Screens.Cheats;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace API.DrippyDevelopment.IMGUI
{
    [KSPAddon(KSPAddon.Startup.Flight | KSPAddon.Startup.SpaceCentre, false)]
    // Core style configuration
    public static class IMGUIStyle
    {
        // Colors matching the terminal theme
        public static readonly Color BackgroundColor = new Color(0.06f, 0.06f, 0.06f, 0.94f);  // ImGuiCol_WindowBg
        public static readonly Color HeaderColor = new Color(0.26f, 0.59f, 0.98f, 0.6f);  // ImGuiCol_Header
        public static readonly Color TextColor = new Color(1.00f, 1.00f, 1.00f, 1.00f);  // ImGuiCol_Text
        public static readonly Color HighlightColor = new Color(0.26f, 0.59f, 0.98f, 1.00f);  // ImGuiCol_ButtonHovered / HeaderHovered
        public static readonly Color AccentColor = new Color(0.26f, 0.59f, 0.98f, 1.00f);  // ImGuiCol_Button / HeaderActive
        public static readonly Color BorderColor = new Color(0.43f, 0.43f, 0.50f, 0.50f);  // ImGuiCol_Border
        public static readonly Color ExpanderColor = new Color(0.26f, 0.59f, 0.98f, 0.45f);  // Custom color for foldout expander
        public static readonly Color DisabledColor = new Color(0.5f, 0.5f, 0.5f, 0.5f); // Color for disabled items
        public static readonly Color WarningColor = new Color(1.0f, 0.5f, 0.0f, 1.0f); // Color for warnings
        public static readonly Color ErrorColor = new Color(0.9f, 0.1f, 0.1f, 1f); // Brighter red for better visibility
        // Cached GUIStyles
        private static GUIStyle _windowStyle;
        private static GUIStyle _headerStyle;
        private static GUIStyle _buttonStyle;
        private static GUIStyle _toggleStyle;
        private static GUIStyle _labelStyle;
        private static GUIStyle _foldoutStyle;
        private static GUIStyle _expandersTextStyle;
        private static GUIStyle _disabledColor;
        private static GUIStyle _warningColor;
        private static GUIStyle _errorColor;

        public static GUIStyle WindowStyle
        {
            get
            {
                if (_windowStyle == null)
                {
                    _windowStyle = new GUIStyle();
                    _windowStyle.normal.background = CreateColorTexture(BackgroundColor);
                    _windowStyle.normal.textColor = TextColor;
                    _windowStyle.font = GetMonospaceFont();
                    _windowStyle.fontSize = 12;
                    _windowStyle.padding = new RectOffset(0, 0, 0, 0);
                    _windowStyle.border = new RectOffset(1, 1, 1, 1);
                }
                return _windowStyle;
            }
        }

        public static GUIStyle HeaderStyle
        {
            get
            {
                if (_headerStyle == null)
                {
                    _headerStyle = new GUIStyle(GUI.skin.label);
                    _headerStyle.normal.textColor = TextColor;
                    _headerStyle.font = GetMonospaceFont();
                    _headerStyle.fontSize = 14;
                    _headerStyle.fontStyle = FontStyle.Normal;
                    _headerStyle.padding = new RectOffset(0, 0, 0, 0);
                    _headerStyle.alignment = TextAnchor.MiddleLeft;
                }
                return _headerStyle;
            }
        }

        public static GUIStyle ButtonStyle
        {
            get
            {
                if (_buttonStyle == null)
                {
                    _buttonStyle = new GUIStyle(GUI.skin.button);
                    _buttonStyle.normal.background = CreateColorTexture(new Color(0.2f, 0.25f, 0.35f, 1f));
                    _buttonStyle.hover.background = CreateColorTexture(HighlightColor);
                    _buttonStyle.active.background = CreateColorTexture(AccentColor);
                    _buttonStyle.normal.textColor = TextColor;
                    _buttonStyle.hover.textColor = Color.white;
                    _buttonStyle.active.textColor = Color.white;
                    _buttonStyle.font = GetMonospaceFont();
                    _buttonStyle.fontSize = 14;
                    _buttonStyle.padding = new RectOffset(8, 8, 4, 4);
                    _buttonStyle.border = new RectOffset(1, 1, 1, 1);
                }
                return _buttonStyle;
            }
        }

        public static GUIStyle ToggleStyle
        {
            get
            {
                if (_toggleStyle == null)
                {
                    _toggleStyle = new GUIStyle(GUI.skin.toggle);
                    _toggleStyle.normal.textColor = TextColor;
                    _toggleStyle.font = GetMonospaceFont();
                    _toggleStyle.fontSize = 14;
                    _toggleStyle.padding = new RectOffset(20, 4, 4, 4);
                }
                return _toggleStyle;
            }
        }

        public static GUIStyle LabelStyle
        {
            get
            {
                if (_labelStyle == null)
                {
                    _labelStyle = new GUIStyle(GUI.skin.label);
                    _labelStyle.normal.textColor = TextColor;
                    _labelStyle.font = GetMonospaceFont();
                    _labelStyle.fontSize = 14;
                    _labelStyle.padding = new RectOffset(4, 4, 2, 2);
                }
                return _labelStyle;
            }
        }

        public static GUIStyle FoldoutStyle
        {
            get
            {
                if (_foldoutStyle == null)
                {
                    _foldoutStyle = new GUIStyle(GUI.skin.toggle);
                    _foldoutStyle.normal.textColor = AccentColor;
                    _foldoutStyle.font = GetMonospaceFont();
                    _foldoutStyle.fontSize = 14;
                    _foldoutStyle.fontStyle = FontStyle.Bold;
                    _foldoutStyle.padding = new RectOffset(20, 4, 4, 4);
                }
                return _foldoutStyle;
            }
        }
        public static GUIStyle expandersTextStyle
        {
            get
            {
                if (_expandersTextStyle == null)
                {
                    _expandersTextStyle = new GUIStyle(GUI.skin.label);
                    _expandersTextStyle.normal.textColor = ExpanderColor;
                    _expandersTextStyle.font = GetMonospaceFont();
                    _expandersTextStyle.fontSize = 14;
                    _expandersTextStyle.padding = new RectOffset(0, 4, 0, 0);
                    _expandersTextStyle.alignment = TextAnchor.MiddleCenter;
                }
                return _expandersTextStyle;
            }
        }
        public static GUIStyle disabledColor
        {
            get
            {
                if (_disabledColor == null)
                {
                    _disabledColor = new GUIStyle(GUI.skin.label);
                    _disabledColor.normal.textColor = DisabledColor;
                    _disabledColor.font = GetMonospaceFont();
                    _disabledColor.fontSize = 14;
                    _disabledColor.padding = new RectOffset(0, 4, 0, 0);
                    _disabledColor.alignment = TextAnchor.MiddleCenter;
                }
                return _disabledColor;
            }
        }
        public static GUIStyle warningColor
        {
            get
            {
                if (_warningColor == null)
                {
                    _disabledColor = new GUIStyle(GUI.skin.label);
                    _disabledColor.normal.textColor = DisabledColor;
                    _disabledColor.font = GetMonospaceFont();
                    _disabledColor.fontSize = 14;
                    _disabledColor.padding = new RectOffset(0, 4, 0, 0);
                    _disabledColor.alignment = TextAnchor.MiddleCenter;
                }
                return _disabledColor;
            }
        }
        public static GUIStyle errorColor
        {
            get
            {
                if (_errorColor == null)
                {
                    _errorColor = new GUIStyle(GUI.skin.label);
                    _errorColor.normal.textColor = ErrorColor;
                    _errorColor.font = GetMonospaceFont();
                    _errorColor.fontSize = 14;
                    _errorColor.padding = new RectOffset(0, 4, 0, 0);
                    _errorColor.alignment = TextAnchor.MiddleCenter;

                }
                return _errorColor;
            }
        }
        public static GUIStyle closeButtonStyle = new GUIStyle(IMGUIStyle.errorColor)
        {
            fontSize = 16,
            alignment = TextAnchor.MiddleCenter,
            normal = { textColor = IMGUIStyle.ErrorColor }, // Red text
            hover = {
            textColor = Color.white, // White text on hover
            background = IMGUIStyle.CreateColorTexture(IMGUIStyle.ErrorColor) // Red background
        },
            active = {
            textColor = Color.white,
            background = IMGUIStyle.CreateColorTexture(new Color(0.8f, 0, 0, 1f)) // Darker red when clicked
        }
        };
        public static Font GetMonospaceFont()
        {
            // Try to find a monospace font, fallback to default
            Font monoFont = Resources.Load<Font>("Fonts/CourierNew") ??
                           Resources.FindObjectsOfTypeAll<Font>().FirstOrDefault(f => f.name.Contains("Courier")) ??
                           GUI.skin.font;
            return monoFont;
        }

        public static Texture2D CreateColorTexture(Color color)
        {
            Texture2D texture = new Texture2D(1, 1);
            texture.SetPixel(0, 0, color);
            texture.Apply();
            return texture;
        }

        public static void ClearCache()
        {
            _windowStyle = null;
            _headerStyle = null;
            _buttonStyle = null;
            _toggleStyle = null;
            _labelStyle = null;
            _foldoutStyle = null;
        }
    }

    // Base interface for all menu items
    public interface IIMGUIMenuItem
    {
        string Label { get; }
        bool IsEnabled { get; set; }
        void OnGUI();
    }

    // Foldout group for organizing menu items
    public class IMGUIFoldout : IIMGUIMenuItem
    {
        public string Label { get; private set; }
        public bool IsEnabled { get; set; } = true;
        public bool IsExpanded { get; set; } = false;
        public List<IIMGUIMenuItem> Children { get; private set; }

        public IMGUIFoldout(string label, bool expanded = false)
        {
            Label = label;
            IsExpanded = expanded;
            Children = new List<IIMGUIMenuItem>();
        }

        public void AddChild(IIMGUIMenuItem item)
        {
            Children.Add(item);
        }

        public void OnGUI()
        {
            if (!IsEnabled) return;

            GUILayout.BeginHorizontal();
            string triangle = IsExpanded ? "▼" : "▶";

            // Create a button style for the triangle
            GUIStyle triangleStyle = IMGUIStyle.expandersTextStyle;
            triangleStyle.normal.textColor = IMGUIStyle.TextColor;
            triangleStyle.font = IMGUIStyle.GetMonospaceFont();
            triangleStyle.fontSize = 14;
            triangleStyle.padding = new RectOffset(0, 4, 0, 0);
            triangleStyle.alignment = TextAnchor.MiddleLeft;

            // Triangle button
            if (GUILayout.Button(triangle, triangleStyle, GUILayout.Width(15)))
            {
                IsExpanded = !IsExpanded;
            }

            // Label
            GUILayout.Label(Label, IMGUIStyle.LabelStyle);

            GUILayout.EndHorizontal();

            if (IsExpanded)
            {
                GUILayout.BeginVertical();
                GUILayout.Space(2);

                foreach (var child in Children)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Space(20); // Indent
                    GUILayout.BeginVertical();
                    child.OnGUI();
                    GUILayout.EndVertical();
                    GUILayout.EndHorizontal();
                }

                GUILayout.EndVertical();
            }
        }
    }
    // Tabs
    public class IMGUITab : IIMGUIMenuItem
    {
        public string Label { get; private set; }
        public bool IsEnabled { get; set; } = true;
        public bool IsSelected { get; set; } = false;
        public System.Action OnSelect { get; set; }
        public IMGUITab(string label, System.Action onSelect = null)
        {
            Label = label;
            OnSelect = onSelect;
        }
        public void OnGUI()
        {
            if (!IsEnabled) return;
            GUIStyle style = new GUIStyle(GUI.skin.button);
            style.normal.textColor = IsSelected ? IMGUIStyle.HighlightColor : IMGUIStyle.TextColor;
            style.hover.textColor = IMGUIStyle.HighlightColor;
            style.active.textColor = IMGUIStyle.AccentColor;
            if (GUILayout.Button(Label, style))
            {
                IsSelected = true;
                OnSelect?.Invoke();
            }
        }
    }
    // Button menu item
    public class IMGUIButton : IIMGUIMenuItem
    {
        public string Label { get; private set; }
        public bool IsEnabled { get; set; } = true;
        public System.Action OnClick { get; set; }

        public IMGUIButton(string label, System.Action onClick = null)
        {
            Label = label;
            OnClick = onClick;
        }

        public void OnGUI()
        {
            if (!IsEnabled) return;

            if (GUILayout.Button(Label, IMGUIStyle.ButtonStyle))
            {
                OnClick?.Invoke();
            }
        }
    }

    // Toggle menu item
    public class IMGUIToggle : IIMGUIMenuItem
    {
        public string Label { get; private set; }
        public bool IsEnabled { get; set; } = true;
        public bool Value { get; set; }
        public System.Action<bool> OnToggle { get; set; }

        public IMGUIToggle(string label, bool initialValue = false, System.Action<bool> onToggle = null)
        {
            Label = label;
            Value = initialValue;
            OnToggle = onToggle;
        }

        public void OnGUI()
        {
            if (!IsEnabled) return;

            bool newValue = GUILayout.Toggle(Value, Label, IMGUIStyle.ToggleStyle);
            if (newValue != Value)
            {
                Value = newValue;
                OnToggle?.Invoke(Value);
            }
        }
    }

    // Label menu item
    public class IMGUILabel : IIMGUIMenuItem
    {
        public string Label { get; private set; }
        public bool IsEnabled { get; set; } = true;

        public IMGUILabel(string label)
        {
            Label = label;
        }

        public void OnGUI()
        {
            if (!IsEnabled) return;
            GUILayout.Label(Label, IMGUIStyle.LabelStyle);
        }
    }

    // Separator
    public class IMGUISeparator : IIMGUIMenuItem
    {
        public string Label => "";
        public bool IsEnabled { get; set; } = true;

        public void OnGUI()
        {
            if (!IsEnabled) return;
            GUILayout.Space(8);
            Rect rect = GUILayoutUtility.GetRect(0, 1, GUILayout.ExpandWidth(true));
            GUI.DrawTexture(rect, IMGUIStyle.CreateColorTexture(IMGUIStyle.BorderColor));
            GUILayout.Space(8);
        }
    }

    // Main window class
    public class IMGUIWindow
    {
        public string Title { get; set; }
        public Rect WindowRect { get; set; }
        public bool IsVisible { get; set; } = true;
        public bool IsDraggable { get; set; } = true;
        public List<IIMGUIMenuItem> MenuItems { get; private set; }
        public Vector2 ScrollPosition { get; set; }

        private bool isResizing = false;
        private Vector2 resizeStartPos;
        private Vector2 resizeStartSize;
        private bool isCollapsed = false;
        private Vector2 defaultSize;
        private Vector2 collapsedSize = new Vector2(200, 24); // Just header height

        public System.Action OnCloseButton;

        private int windowId;
        private static int nextWindowId = 1000;

        public IMGUIWindow(string title, Rect initialRect)
        {
            Title = title;
            WindowRect = initialRect;
            MenuItems = new List<IIMGUIMenuItem>();
            windowId = nextWindowId++;
            defaultSize = new Vector2(initialRect.width, initialRect.height);
        }

        public void AddMenuItem(IIMGUIMenuItem item)
        {
            MenuItems.Add(item);
        }

        public void OnGUI()
        {
            if (!IsVisible) return;

            if (IsDraggable)
            {
                WindowRect = GUI.Window(windowId, WindowRect, DrawWindow, "", IMGUIStyle.WindowStyle);
            }
            else
            {
                GUI.Window(windowId, WindowRect, DrawWindow, "", IMGUIStyle.WindowStyle);
            }
        }

        private void DrawWindow(int id)
        {
            // Draw blue header bar across full width
            Rect headerRect = new Rect(0, 0, WindowRect.width, 20);
            GUI.DrawTexture(headerRect, IMGUIStyle.CreateColorTexture(IMGUIStyle.HeaderColor));

            // Collapse/Expand button
            Rect collapseButtonRect = new Rect(4, 2, 16, 16);
            GUIStyle collapseButtonStyle = IMGUIStyle.expandersTextStyle;
            collapseButtonStyle.normal.textColor = IMGUIStyle.TextColor;
            collapseButtonStyle.font = IMGUIStyle.GetMonospaceFont();
            collapseButtonStyle.fontSize = 12;
            collapseButtonStyle.padding = new RectOffset(0, 0, 0, 0);
            collapseButtonStyle.normal.background = null;
            collapseButtonStyle.hover.background = IMGUIStyle.CreateColorTexture(IMGUIStyle.HighlightColor);
            collapseButtonStyle.active.background = IMGUIStyle.CreateColorTexture(IMGUIStyle.AccentColor);

            string collapseSymbol = isCollapsed ? "▶" : "▼";
            if (GUI.Button(collapseButtonRect, collapseSymbol, collapseButtonStyle))
            {
                ToggleCollapse();
            }

            // Draw title text on header (offset to make room for collapse button)
            GUI.Label(new Rect(24, 2, WindowRect.width - 30, 16), Title, IMGUIStyle.HeaderStyle);

            // Only draw content if not collapsed
            if (!isCollapsed)
            {
                // Content area below header
                GUILayout.BeginArea(new Rect(8, 24, WindowRect.width - 16, WindowRect.height - 40));
                GUILayout.BeginVertical();

                // Content with scroll
                ScrollPosition = GUILayout.BeginScrollView(ScrollPosition);

                foreach (var item in MenuItems)
                {
                    item.OnGUI();
                    GUILayout.Space(2);
                }

                GUILayout.EndScrollView();
                GUILayout.EndVertical();
                GUILayout.EndArea();

                // Draw resize handle in bottom right corner
                DrawResizeHandle();
            }
            Rect closeButtonRect = new Rect(WindowRect.width - 24, 2, 20, 16);

            if (GUI.Button(closeButtonRect, "×", IMGUIStyle.closeButtonStyle))
            {
                OnCloseButton?.Invoke();
                return;
            }
            if (IsDraggable)
            {
                GUI.DragWindow(headerRect); // Only drag from header
            }
        }
        public void RemoveWindow(IMGUIWindow window)
        {
            if (window == null) return;
            MenuItems.RemoveAll(item => item is IMGUIWindow && ((IMGUIWindow)item).windowId == window.windowId);
            IMGUIStyle.ClearCache(); // Clear cached styles to force recreation
        }
        private void ToggleCollapse()
        {
            if (isCollapsed)
            {
                // Expand to default size
                WindowRect = new Rect(WindowRect.x, WindowRect.y, defaultSize.x, defaultSize.y);
                isCollapsed = false;
            }
            else
            {
                // Collapse to header only
                WindowRect = new Rect(WindowRect.x, WindowRect.y, collapsedSize.x, collapsedSize.y);
                isCollapsed = true;
            }
        }

        private Texture2D triangleTex;

        private Texture2D CreateTriangleTexture(int size, Color col)
        {
            Texture2D tex = new Texture2D(size, size, TextureFormat.RGBA32, false);
            tex.filterMode = FilterMode.Point;

            Color[] pixels = new Color[size * size];

            // Fill pixels: northwest-facing right triangle
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (x + y >= size) // keep only bottom-left half
                        pixels[y * size + x] = col;
                    else
                        pixels[y * size + x] = Color.clear;
                }
            }

            tex.SetPixels(pixels);
            tex.Apply();
            return tex;
        }

        private void DrawResizeHandle()
        {
            float handleSize = 16f;
            Rect handleRect = new Rect(WindowRect.width - handleSize, WindowRect.height - handleSize, handleSize, handleSize);

            Event e = Event.current;

            if (triangleTex == null)
                triangleTex = CreateTriangleTexture((int)handleSize, IMGUIStyle.AccentColor);

            // draw
            GUI.DrawTexture(handleRect, triangleTex);

            // --- resize logic ---
            if (e.type == EventType.MouseDown && handleRect.Contains(e.mousePosition))
            {
                isResizing = true;
                resizeStartPos = e.mousePosition;
                resizeStartSize = new Vector2(WindowRect.width, WindowRect.height);
                e.Use();
            }
            else if (e.type == EventType.MouseDrag && isResizing)
            {
                Vector2 deltaSize = e.mousePosition - resizeStartPos;
                WindowRect = new Rect(WindowRect.x, WindowRect.y,
                    Mathf.Max(200, resizeStartSize.x + deltaSize.x),
                    Mathf.Max(150, resizeStartSize.y + deltaSize.y));
                e.Use();
            }
            else if (e.type == EventType.MouseUp && isResizing)
            {
                isResizing = false;
                e.Use();
            }

            // --- hover effect ---
            if (handleRect.Contains(e.mousePosition))
            {
                Texture2D hoverTex = CreateTriangleTexture((int)handleSize, new Color(
                    IMGUIStyle.AccentColor.r * 1.2f,
                    IMGUIStyle.AccentColor.g * 1.2f,
                    IMGUIStyle.AccentColor.b * 1.2f
                ));

                GUI.DrawTexture(handleRect, hoverTex);
            }
        }


        // Window manager
        [KSPAddon(KSPAddon.Startup.Flight | KSPAddon.Startup.SpaceCentre, false)]
        public class IMGUIWindowManager : MonoBehaviour
        {
            private List<IMGUIWindow> windows = new List<IMGUIWindow>();
            private bool uiVisible = true;
            private KeyCode toggleKey = KeyCode.F2;

            void Awake()
            {
                Debug.Log("[IMGUI4KSP] Initializing...");
                LoadConfig();

            }

            public void LoadConfig()
            {
                foreach (var node in GameDatabase.Instance.GetConfigNodes("IMGUI4KSP/config"))
                {
                    if (node.HasValue("toggleKey"))
                    {
                        if (Enum.TryParse(node.GetValue("toggleKey"), true, out KeyCode key))
                        {
                            toggleKey = key;
                            Debug.Log($"[IMGUI4KSP] Using toggle key: {toggleKey}");
                        }
                    }
                }
            }

            void Update()
            {
                if (Input.GetKeyDown(toggleKey))
                {
                    uiVisible = !uiVisible;
                    Debug.Log($"[IMGUI4KSP] UI toggled: {uiVisible}");
                }
            }

            void OnGUI()
            {
                if (!uiVisible) return;
                foreach (var window in windows)
                {
                    window.OnGUI();
                }
            }

            public IMGUIWindow CreateWindow(string title, Vector2 position, Vector2 size)
            {
                var window = new IMGUIWindow(title, new Rect(position.x, position.y, size.x, size.y));
                windows.Add(window);
                return window;
            }
            public IMGUIWindow DestroyWindow(IMGUIWindow window)
            {
                if (window != null && windows.Contains(window))
                {
                    windows.Remove(window);
                    // Additional cleanup if needed

                }
                return null;
            }
        }

    }

}

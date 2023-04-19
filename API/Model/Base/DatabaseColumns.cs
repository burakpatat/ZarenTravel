using Model.Concrete;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Model.Concrete
{

    public class SqlColumn
    {


        private string _ColumnName;
        public string ColumnName { get { return _ColumnName; } set { _ColumnName = value; } }

        private string _DbType;
        public string DbType
        {
            get { return _DbType; }
            set { _DbType = value; }
        }

        private bool? _IsNullable;
        public bool? IsNullable
        {
            get { return _IsNullable; }
            set { _IsNullable = value; }
        }

        private int? _MaxLength;
        public int? MaxLength
        {
            get { return _MaxLength; }
            set { _MaxLength = value; }
        }

        private string _TableName;
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }
        private bool? _IsPrimary;
        public bool? IsPrimary
        {
            get { return _IsPrimary; }
            set { _IsPrimary = value; }
        }
    }


    public class SchemeTableColumns : SqlColumn
    {


        private int? _IsNumber;
        public int? IsNumber
        {
            get => _IsNumber;
            set => _IsNumber = value;
        }

        private int? _IsDecimal;
        public int? IsDecimal
        {
            get { return _IsDecimal; }
            set { _IsDecimal = value; }
        }

        private int? _IsDatetime;
        public int? IsDatetime
        {
            get { return _IsDatetime; }
            set { _IsDatetime = value; }
        }
        private string _SchemaName;
        public string SchemaName
        {
            get { return _SchemaName; }
            set { _SchemaName = value; }
        }

        private string _DbTypeWithMaxLength;
        public string DbTypeWithMaxLengt
        {
            get { return _DbTypeWithMaxLength; }
            set { _DbTypeWithMaxLength = value; }
        }

        private bool? _IsRequired;
        public bool? IsRequired
        {
            get { return _IsRequired; }
            set { _IsRequired = value; }
        }

        private string _DefaultValue;
        public string DefaultValue
        {
            get { return _DefaultValue; }
            set { _DefaultValue = value; }
        }

        private int? _TableOrder;
        public int? TableOrder
        {
            get { return _TableOrder; }
            set { _TableOrder = value; }
        }
    }


    public class DatabaseColumns : SchemeTableColumns
    {

        private string _CMSDisplayName;
        public string CMSDisplayName
        {
            get { return _CMSDisplayName; }
            set { _CMSDisplayName = value; }
        }

        private string _PlaceHolder;
        public string PlaceHolder
        {
            get { return _PlaceHolder; }
            set { _PlaceHolder = value; }
        }
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }


        private string _InputTypeStr;
        public string InputType
        {
            get { return _InputTypeStr; }
            set { _InputTypeStr = value; }
        }


        private string _DotNetType;
        public string DotNetType
        {
            get { return _DotNetType; }
            set { _DotNetType = value; }
        }
        private string _DotNetTypeWithNullableInfo;
        public string DotNetTypeWithNullableInfo
        {
            get { return _DotNetTypeWithNullableInfo; }
            set { _DotNetTypeWithNullableInfo = value; }
        }


        private bool _HasDefaultValue;
        public bool HasDefaultValue
        {
            get { return _HasDefaultValue; }
            set { _HasDefaultValue = value; }
        }


        private bool? _IsPublic;
        public bool? IsPublic
        {
            get { return _IsPublic; }
            set { _IsPublic = value; }
        }


        private bool? _IsSecondry;
        public bool? IsSecondry
        {
            get { return _IsSecondry; }
            set { _IsSecondry = value; }
        }

        public ForeignKeyTable ForeignKeyTables { get; set; }

        public FKDetails FKDetails { get; set; }
        public Dictionary<string, string> ForeignKeyTablesStr { get; set; }

        private string _Collation;
        public string Collation
        {
            get { return _Collation; }
            set { _Collation = value; }
        }
        private bool? _IsRTL;
        public bool? IsRTL
        {
            get { return _IsRTL; }
            set { _IsRTL = value; }
        }

        private bool? _IsRoutingField;
        public bool? IsRoutingField
        {
            get { return _IsRoutingField; }
            set { _IsRoutingField = value; }
        }


        private bool? _HasShowedOnDetail;
        public bool? HasShowedOnDetail
        {
            get { return _HasShowedOnDetail; }
            set { _HasShowedOnDetail = value; }
        }
        private string _DetailDataSource;
        public string DetailDataSource
        {
            get { return _DetailDataSource; }
            set { _DetailDataSource = value; }
        }
        private string _DetailSelectedValue;
        public string DetailSelectedValue
        {
            get { return _DetailSelectedValue; }
            set { _DetailSelectedValue = value; }
        }
        private string _DetailSelectedText;
        public string DetailSelectedText
        {
            get { return _DetailSelectedText; }
            set { _DetailSelectedText = value; }
        }

        private bool? _HasShowedOnList;
        public bool? HasShowedOnList
        {
            get { return _HasShowedOnList; }
            set { _HasShowedOnList = value; }
        }

        private bool? _IsFilterOnList;
        public bool? IsFilterOnList
        {
            get { return _IsFilterOnList; }
            set { _IsFilterOnList = value; }
        }
        private string _FilterInputTypeOnList;
        public string FilterInputTypeOnList
        {
            get { return _FilterInputTypeOnList; }
            set { _FilterInputTypeOnList = value; }
        }

        private string _FilterSelectDataSourceOnList;
        public string FilterSelectDataSourceOnList
        {
            get { return _FilterSelectDataSourceOnList; }
            set { _FilterSelectDataSourceOnList = value; }
        }

        private string _FilterSelectedValue;
        public string FilterSelectedValue
        {
            get { return _FilterSelectedValue; }
            set { _FilterSelectedValue = value; }
        }
        private string _FilterSelectedText;
        public string FilterSelectedText
        {
            get { return _FilterSelectedText; }
            set { _FilterSelectedText = value; }
        }

        private bool? _HasMultipleFilterOnList;
        public bool? HasMultipleFilterOnList
        {
            get { return _HasMultipleFilterOnList; }
            set { _HasMultipleFilterOnList = value; }
        }


        private bool? _IsSortable;
        public bool? IsSortable
        {
            get { return _IsSortable; }
            set { _IsSortable = value; }
        }

        private bool? _IsOrderable;
        public bool? IsOrderable
        {
            get { return _IsOrderable; }
            set { _IsOrderable = value; }
        }

        private bool? _CanEditOnList;
        public bool? CanEditOnList
        {
            get { return _CanEditOnList; }
            set { _CanEditOnList = value; }
        }

        private bool? _IsEditable;
        public bool? IsEditable
        {
            get { return _IsEditable; }
            set { _IsEditable = value; }
        }

        private bool? _DetailOnPopup;
        public bool? DetailOnPopup
        {
            get { return _DetailOnPopup; }
            set { _DetailOnPopup = value; }
        }

        private bool? _AddMoreDetailBtnOnList;
        public bool? AddMoreDetailBtnOnList
        {
            get { return _AddMoreDetailBtnOnList; }
            set { _AddMoreDetailBtnOnList = value; }
        }

        private string _Resize;
        public string Resize
        {
            get { return _Resize; }
            set { _Resize = value; }
        }

        private string _UploadLimit;
        public string UploadLimit
        {
            get { return _UploadLimit; }
            set { _UploadLimit = value; }
        }

        private bool? _IsLanguageField;
        public bool? IsLanguageField
        {
            get { return _IsLanguageField; }
            set { _IsLanguageField = value; }
        }

        private string _JsonName;
        public string JsonName
        {
            get { return _JsonName; }
            set { _JsonName = value; }
        }
        private string _Tooltip;
        public string Tooltip
        {
            get { return _Tooltip; }
            set { _Tooltip = value; }
        }

        private string _Mask;
        public string Mask
        {
            get { return _Mask; }
            set { _Mask = value; }
        }

        private string _ErrorDescription;
        public string ErrorDescription
        {
            get { return _ErrorDescription; }
            set { _ErrorDescription = value; }
        }

        private string _HelpDescription;
        public string HelpDescription
        {
            get { return _HelpDescription; }
            set { _HelpDescription = value; }
        }
        [JsonPropertyName("__VIEWSTATE")]
        public string state { get; set; }

        [JsonPropertyName("__VIEWSTATEGENERATOR")]
        public string stateno { get; set; }
    }

    public class ForeignKeyTable
    {
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string RefTableName { get; set; }
        public string RefColumnName { get; set; }

        public string TextColumnName { get; set; }

        public string DefaultText { get; set; }
    }

    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Aligner
    {
        [JsonPropertyName("grid")]
        public List<string> Grid;

        [JsonPropertyName("flex")]
        public List<string> Flex;
    }

    public class Animation
    {
        [JsonPropertyName("animation")]
        public string AnimationDetail;

        [JsonPropertyName("animation-duration")]
        public string AnimationDuration;

        [JsonPropertyName("animation-name")]
        public string AnimationName;

        [JsonPropertyName("animation-iteration-count")]
        public string AnimationIterationCount;

        [JsonPropertyName("animation-direction")]
        public string AnimationDirection;
    }

    public class ApiCall
    {
        [JsonPropertyName("EndPoint")]
        public string EndPoint;

        [JsonPropertyName("HttpMethod")]
        public string HttpMethod;

        [JsonPropertyName("Data")]
        public string Data;

        [JsonPropertyName("Success")]
        public string Success;

        [JsonPropertyName("Error")]
        public string Error;

        [JsonPropertyName("Header")]
        public string Header;
    }

    public class AppSettings
    {
        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("isMobile")]
        public string IsMobile;

        [JsonPropertyName("bootstrap")]
        public Bootstrap Bootstrap;

        [JsonPropertyName("header")]
        public Header Header;

        [JsonPropertyName("sidebar")]
        public Sidebar Sidebar;

        [JsonPropertyName("scrollBar")]
        public ScrollBar ScrollBar;

        [JsonPropertyName("content")]
        public Content Content;

        [JsonPropertyName("layout")]
        public Layout Layout;

        [JsonPropertyName("scrollToTopBtn")]
        public ScrollToTopBtn ScrollToTopBtn;

        [JsonPropertyName("scrollTo")]
        public ScrollTo ScrollTo;

        [JsonPropertyName("themePanel")]
        public ThemePanel ThemePanel;

        [JsonPropertyName("dismissClass")]
        public DismissClass DismissClass;

        [JsonPropertyName("toggleClass")]
        public ToggleClass ToggleClass;

        [JsonPropertyName("color")]
        public Colors Color;

        [JsonPropertyName("card")]
        public Card Card;

        [JsonPropertyName("init")]
        public Init Init;
    }

    public class Arrow
    {
        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("class")]
        public string Class;
    }

    public class Attrs
    {
        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("name")]
        public string Name;

        [JsonPropertyName("required")]
        public bool Required;

        [JsonPropertyName("type")]
        public string Type;

        [JsonPropertyName("className")]
        public string ClassName;

        [JsonPropertyName("mask")]
        public bool Mask;

        [JsonPropertyName("maskFormat")]
        public string MaskFormat;

        [JsonPropertyName("value")]
        public string Value;

        [JsonPropertyName("href")]
        public string Href;

        [JsonPropertyName("openNewTab")]
        public bool OpenNewTab;

        [JsonPropertyName("height")]
        public int Height;

        [JsonPropertyName("width")]
        public string Width;

        [JsonPropertyName("autoFocus")]
        public bool AutoFocus;

        [JsonPropertyName("IsReadonly")]
        public bool IsReadonly;

        [JsonPropertyName("IsDisable")]
        public bool IsDisable;

        [JsonPropertyName("startDate")]
        public string StartDate;

        [JsonPropertyName("endDate")]
        public string EndDate;

        [JsonPropertyName("defaultDate")]
        public string DefaultDate;

        [JsonPropertyName("ApiUrl")]
        public string ApiUrl;

        [JsonPropertyName("function")]
        public string Function;

        [JsonPropertyName("responsive")]
        public Responsive Responsive;

        [JsonPropertyName("icon")]
        public string Icon;
    }

    public class Backdrop
    {
        [JsonPropertyName("class")]
        public string Class;
    }

    public class Bootstrap
    {
        [JsonPropertyName("tooltip")]
        public Tooltip Tooltip;

        [JsonPropertyName("popover")]
        public Popover Popover;

        [JsonPropertyName("modal")]
        public Modal Modal;

        [JsonPropertyName("nav")]
        public Nav Nav;
    }

    public class BoxedLayout
    {
        [JsonPropertyName("class")]
        public string Class;
    }

    public class Card
    {
        [JsonPropertyName("expand")]
        public Expand Expand;
    }

    public class Colors
    {
        [JsonPropertyName("theme")]
        public string Theme;

        [JsonPropertyName("blue")]
        public string Blue;

        [JsonPropertyName("green")]
        public string Green;

        [JsonPropertyName("orange")]
        public string Orange;

        [JsonPropertyName("red")]
        public string Red;

        [JsonPropertyName("cyan")]
        public string Cyan;

        [JsonPropertyName("purple")]
        public string Purple;

        [JsonPropertyName("yellow")]
        public string Yellow;

        [JsonPropertyName("indigo")]
        public string Indigo;

        [JsonPropertyName("pink")]
        public string Pink;

        [JsonPropertyName("black")]
        public string Black;

        [JsonPropertyName("white")]
        public string White;

        [JsonPropertyName("gray")]
        public string Gray;

        [JsonPropertyName("dark")]
        public string Dark;

        [JsonPropertyName("gray100")]
        public string Gray100;

        [JsonPropertyName("gray200")]
        public string Gray200;

        [JsonPropertyName("gray300")]
        public string Gray300;

        [JsonPropertyName("gray400")]
        public string Gray400;

        [JsonPropertyName("gray500")]
        public string Gray500;

        [JsonPropertyName("gray600")]
        public string Gray600;

        [JsonPropertyName("gray700")]
        public string Gray700;

        [JsonPropertyName("gray800")]
        public string Gray800;

        [JsonPropertyName("gray900")]
        public string Gray900;

        [JsonPropertyName("themeRgb")]
        public string ThemeRgb;

        [JsonPropertyName("blueRgb")]
        public string BlueRgb;

        [JsonPropertyName("greenRgb")]
        public string GreenRgb;

        [JsonPropertyName("orangeRgb")]
        public string OrangeRgb;

        [JsonPropertyName("redRgb")]
        public string RedRgb;

        [JsonPropertyName("cyanRgb")]
        public string CyanRgb;

        [JsonPropertyName("purpleRgb")]
        public string PurpleRgb;

        [JsonPropertyName("yellowRgb")]
        public string YellowRgb;

        [JsonPropertyName("indigoRgb")]
        public string IndigoRgb;

        [JsonPropertyName("pinkRgb")]
        public string PinkRgb;

        [JsonPropertyName("blackRgb")]
        public string BlackRgb;

        [JsonPropertyName("whiteRgb")]
        public string WhiteRgb;

        [JsonPropertyName("grayRgb")]
        public string GrayRgb;

        [JsonPropertyName("darkRgb")]
        public string DarkRgb;

        [JsonPropertyName("gray100Rgb")]
        public string Gray100Rgb;

        [JsonPropertyName("gray200Rgb")]
        public string Gray200Rgb;

        [JsonPropertyName("gray300Rgb")]
        public string Gray300Rgb;

        [JsonPropertyName("gray400Rgb")]
        public string Gray400Rgb;

        [JsonPropertyName("gray500Rgb")]
        public string Gray500Rgb;

        [JsonPropertyName("gray600Rgb")]
        public string Gray600Rgb;

        [JsonPropertyName("gray700Rgb")]
        public string Gray700Rgb;

        [JsonPropertyName("gray800Rgb")]
        public string Gray800Rgb;

        [JsonPropertyName("gray900Rgb")]
        public string Gray900Rgb;
    }

    public class Container
    {
        [JsonPropertyName("class")]
        public string Class;
    }

    public class Content
    {
        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("class")]
        public string Class;

        [JsonPropertyName("fullHeight")]
        public FullHeight FullHeight;

        [JsonPropertyName("fullWidth")]
        public FullWidth FullWidth;
    }

    public class CustomParams
    {
    }

    public class DelayedOptions
    {
        [JsonPropertyName("delay_success_milliseconds")]
        public int DelaySuccessMilliseconds;

        [JsonPropertyName("delay_fail_milliseconds")]
        public int DelayFailMilliseconds;

        [JsonPropertyName("sending")]
        public string Sending;

        [JsonPropertyName("send_fail")]
        public string SendFail;

        [JsonPropertyName("send_success")]
        public string SendSuccess;

        [JsonPropertyName("fail_color")]
        public string FailColor;

        [JsonPropertyName("success_color")]
        public string SuccessColor;

        [JsonPropertyName("custom_html_success")]
        public string CustomHtmlSuccess;

        [JsonPropertyName("custom_html_fail")]
        public string CustomHtmlFail;
    }

    public class DismissClass
    {
        [JsonPropertyName("toggleAttr")]
        public string ToggleAttr;

        [JsonPropertyName("targetAttr")]
        public string TargetAttr;
    }

    public class Event
    {
        [JsonPropertyName("OnClick")]
        public List<OnClick> OnClick;

        [JsonPropertyName("OnChange")]
        public List<OnChange> OnChange;

        [JsonPropertyName("OnFocus")]
        public List<OnFocus> OnFocus;

        [JsonPropertyName("OnFocusOut")]
        public List<OnFocusOut> OnFocusOut;

        [JsonPropertyName("OnHover")]
        public List<OnHover> OnHover;

        [JsonPropertyName("OnLoad")]
        public List<OnLoad> OnLoad;

        [JsonPropertyName("OnInterval")]
        public List<OnInterval> OnInterval;
    }

    public class Event2
    {
        [JsonPropertyName("hidden")]
        public string Hidden;
    }

    public class Expand
    {
        [JsonPropertyName("status")]
        public bool Status;

        [JsonPropertyName("toggleAttr")]
        public string ToggleAttr;

        [JsonPropertyName("toggleTitle")]
        public string ToggleTitle;

        [JsonPropertyName("class")]
        public string Class;
    }

    public class FloatSubmenu
    {
        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("dom")]
        public string Dom;

        [JsonPropertyName("timeout")]
        public string Timeout;

        [JsonPropertyName("class")]
        public string Class;

        [JsonPropertyName("container")]
        public Container Container;

        [JsonPropertyName("arrow")]
        public Arrow Arrow;

        [JsonPropertyName("line")]
        public Line Line;

        [JsonPropertyName("overflow")]
        public Overflow Overflow;
    }

    public class SystemFonts
    {
        [JsonPropertyName("family")]
        public string Family;

        [JsonPropertyName("size")]
        public string Size;

        [JsonPropertyName("weight")]
        public string Weight;
    }

    public class FullHeight
    {
        [JsonPropertyName("class")]
        public string Class;
    }

    public class FullWidth
    {
        [JsonPropertyName("class")]
        public string Class;
    }

    public class Header
    {
        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("class")]
        public string Class;

        [JsonPropertyName("hasScrollClass")]
        public string HasScrollClass;
    }

    public class Headings
    {
        [JsonPropertyName("mark")]
        public string Mark;

        [JsonPropertyName("del")]
        public string Del;

        [JsonPropertyName("s")]
        public string S;

        [JsonPropertyName("ins")]
        public string Ins;

        [JsonPropertyName("u")]
        public string U;

        [JsonPropertyName("small")]
        public string Small;

        [JsonPropertyName("strong")]
        public string Strong;

        [JsonPropertyName("em")]
        public string Em;
    }

    public class HtmlTemplate
    {
        [JsonPropertyName("input")]
        public string Input;

        [JsonPropertyName("label")]
        public string Label;

        [JsonPropertyName("textarea")]
        public string Textarea;

        [JsonPropertyName("editor")]
        public string Editor;

        [JsonPropertyName("color")]
        public string Colors;

        [JsonPropertyName("placeholderText")]
        public string PlaceholderText;

        [JsonPropertyName("password")]
        public string Password;

        [JsonPropertyName("rangeSingle")]
        public string RangeSingle;

        [JsonPropertyName("multiUpload")]
        public string MultiUpload;

        [JsonPropertyName("datePicker")]
        public string DatePicker;

        [JsonPropertyName("sliderDefault")]
        public string SliderDefault;

        [JsonPropertyName("sliderRange")]
        public string SliderRange;

        [JsonPropertyName("sliderTooltip")]
        public string SliderTooltip;

        [JsonPropertyName("sliderDisabled")]
        public string SliderDisabled;

        [JsonPropertyName("sliderVertical")]
        public string SliderVertical;

        [JsonPropertyName("select")]
        public string Select;

        [JsonPropertyName("selectMultiple")]
        public string SelectMultiple;

        [JsonPropertyName("optGroup")]
        public string OptGroup;

        [JsonPropertyName("tagIt")]
        public string TagIt;

        [JsonPropertyName("datepickerIcon")]
        public string DatepickerIcon;

        [JsonPropertyName("datepickerDaterange")]
        public string DatepickerDaterange;

        [JsonPropertyName("file")]
        public string File;

        [JsonPropertyName("check")]
        public string Check;

        [JsonPropertyName("radio")]
        public string Radio;

        [JsonPropertyName("switch")]
        public string Switch;

        [JsonPropertyName("userList")]
        public string UserList;

        [JsonPropertyName("button")]
        public string Button;

        [JsonPropertyName("image")]
        public string Image;
    }

    public class Icons
    {
        [JsonPropertyName("fas")]
        public List<string> Fas;

        [JsonPropertyName("fab")]
        public List<string> Fab;

        [JsonPropertyName("far")]
        public List<string> Far;
    }

    public class Init
    {
        [JsonPropertyName("attr")]
        public string Attr;
    }

    public class InputProperty
    {
        [JsonPropertyName("InputName")]
        public string InputName;

        [JsonPropertyName("label")]
        public string Label;

        [JsonPropertyName("errorTemplate")]
        public string ErrorTemplate;

        [JsonPropertyName("validationTemplate")]
        public string ValidationTemplate;

        [JsonPropertyName("attrs")]
        public Attrs Attrs;

        [JsonPropertyName("Events")]
        public List<Event> Events;
    }

    public class Layout
    {
        [JsonPropertyName("sidebarLight")]
        public SidebarLight SidebarLight;

        [JsonPropertyName("sidebarEnd")]
        public SidebarEnd SidebarEnd;

        [JsonPropertyName("sidebarWide")]
        public SidebarWide SidebarWide;

        [JsonPropertyName("sidebarMinified")]
        public SidebarMinified SidebarMinified;

        [JsonPropertyName("sidebarTwo")]
        public SidebarTwo SidebarTwo;

        [JsonPropertyName("withoutHeader")]
        public WithoutHeader WithoutHeader;

        [JsonPropertyName("withoutSidebar")]
        public WithoutSidebar WithoutSidebar;

        [JsonPropertyName("topMenu")]
        public TopMenu TopMenu;

        [JsonPropertyName("boxedLayout")]
        public BoxedLayout BoxedLayout;
    }

    public class Line
    {
        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("class")]
        public string Class;
    }

    public class Menu
    {
        [JsonPropertyName("class")]
        public string Class;

        [JsonPropertyName("initAttr")]
        public string InitAttr;

        [JsonPropertyName("animationTime")]
        public int AnimationTime;

        [JsonPropertyName("itemClass")]
        public string ItemClass;

        [JsonPropertyName("itemLinkClass")]
        public string ItemLinkClass;

        [JsonPropertyName("hasSubClass")]
        public string HasSubClass;

        [JsonPropertyName("activeClass")]
        public string ActiveClass;

        [JsonPropertyName("expandingClass")]
        public string ExpandingClass;

        [JsonPropertyName("expandClass")]
        public string ExpandClass;

        [JsonPropertyName("submenu")]
        public Submenu Submenu;
    }

    public class Minify
    {
        [JsonPropertyName("toggleAttr")]
        public string ToggleAttr;

        [JsonPropertyName("toggledClass")]
        public string ToggledClass;

        [JsonPropertyName("cookieName")]
        public string CookieName;
    }

    public class Mobile
    {
        [JsonPropertyName("toggleAttr")]
        public string ToggleAttr;

        [JsonPropertyName("dismissAttr")]
        public string DismissAttr;

        [JsonPropertyName("toggledClass")]
        public string ToggledClass;

        [JsonPropertyName("closedClass")]
        public string ClosedClass;

        [JsonPropertyName("backdrop")]
        public Backdrop Backdrop;
    }

    public class Modal
    {
        [JsonPropertyName("attr")]
        public string Attr;

        [JsonPropertyName("dismissAttr")]
        public string DismissAttr;

        [JsonPropertyName("event")]
        public Event Event;
    }

    public class Nav
    {
        [JsonPropertyName("class")]
        public string Class;

        [JsonPropertyName("tabs")]
        public Tabs Tabs;
    }

    public class OnChange
    {
        [JsonPropertyName("CustomScript")]
        public string CustomScript;

        [JsonPropertyName("CallMethod")]
        public string CallMethod;

        [JsonPropertyName("ApiCall")]
        public List<ApiCall> ApiCall;
    }

    public class OnClick
    {
        [JsonPropertyName("CustomScript")]
        public string CustomScript;

        [JsonPropertyName("CallMethod")]
        public string CallMethod;

        [JsonPropertyName("ApiCall")]
        public List<ApiCall> ApiCall;
    }

    public class OnFocus
    {
        [JsonPropertyName("CustomScript")]
        public string CustomScript;

        [JsonPropertyName("CallMethod")]
        public string CallMethod;

        [JsonPropertyName("ApiCall")]
        public List<ApiCall> ApiCall;
    }

    public class OnFocusOut
    {
        [JsonPropertyName("CustomScript")]
        public string CustomScript;

        [JsonPropertyName("CallMethod")]
        public string CallMethod;

        [JsonPropertyName("ApiCall")]
        public List<ApiCall> ApiCall;
    }

    public class OnHover
    {
        [JsonPropertyName("CustomScript")]
        public string CustomScript;

        [JsonPropertyName("CallMethod")]
        public string CallMethod;

        [JsonPropertyName("ApiCall")]
        public List<ApiCall> ApiCall;
    }

    public class OnInterval
    {
        [JsonPropertyName("CustomScript")]
        public string CustomScript;

        [JsonPropertyName("CallMethod")]
        public string CallMethod;

        [JsonPropertyName("ApiCall")]
        public List<ApiCall> ApiCall;
    }

    public class OnLoad
    {
        [JsonPropertyName("CustomScript")]
        public string CustomScript;

        [JsonPropertyName("CallMethod")]
        public string CallMethod;

        [JsonPropertyName("ApiCall")]
        public List<ApiCall> ApiCall;
    }

    public class Overflow
    {
        [JsonPropertyName("class")]
        public string Class;
    }

    public class Pages
    {
        [JsonPropertyName("tableName")]
        public string TableName;

        [JsonPropertyName("pageName")]
        public string PageName;

        [JsonPropertyName("requestParam")]
        public List<string> RequestParam;

        [JsonPropertyName("leftMenu")]
        public List<string> LeftMenu;
    }

    public class PageTemplates
    {
        [JsonPropertyName("cardGroup")]
        public string CardGroup;

        [JsonPropertyName("card")]
        public string Card;

        [JsonPropertyName("cardExpandable")]
        public string CardExpandable;

        [JsonPropertyName("cardWithTitleAndDescription")]
        public string CardWithTitleAndDescription;

        [JsonPropertyName("cardBgBorder")]
        public string CardBgBorder;

        [JsonPropertyName("cardColorBorder")]
        public string CardColorBorder;

        [JsonPropertyName("cardImageTitleText")]
        public string CardImageTitleText;

        [JsonPropertyName("cardImageOverlayTitleText")]
        public string CardImageOverlayTitleText;

        [JsonPropertyName("cardHorizontal")]
        public string CardHorizontal;

        [JsonPropertyName("cardUlContainer")]
        public string CardUlContainer;

        [JsonPropertyName("cardListItemUrl")]
        public string CardListItemUrl;

        [JsonPropertyName("cardListItem")]
        public string CardListItem;

        [JsonPropertyName("cardUlInlineContainer")]
        public string CardUlInlineContainer;

        [JsonPropertyName("cardInlineItem")]
        public string CardInlineItem;

        [JsonPropertyName("navigationContainer")]
        public string NavigationContainer;

        [JsonPropertyName("navigationLiItem")]
        public string NavigationLiItem;

        [JsonPropertyName("rowMasonry")]
        public string RowMasonry;

        [JsonPropertyName("rowDefault")]
        public string RowDefault;

        [JsonPropertyName("colContainer")]
        public string ColContainer;

        [JsonPropertyName("col")]
        public string Col;

        [JsonPropertyName("aHref")]
        public string AHref;

        [JsonPropertyName("toastContainer")]
        public string ToastContainer;

        [JsonPropertyName("toastItem")]
        public string ToastItem;

        [JsonPropertyName("toastDetailedItem")]
        public string ToastDetailedItem;

        [JsonPropertyName("modalBasic")]
        public string ModalBasic;

        [JsonPropertyName("modalLarge")]
        public string ModalLarge;

        [JsonPropertyName("modalSmall")]
        public string ModalSmall;

        [JsonPropertyName("modalXlarge")]
        public string ModalXlarge;

        [JsonPropertyName("modalCover")]
        public string ModalCover;

        [JsonPropertyName("tooltip")]
        public string Tooltip;

        [JsonPropertyName("blockQuote")]
        public string BlockQuote;

        [JsonPropertyName("table")]
        public string Table;

        [JsonPropertyName("tab")]
        public string Tab;

        [JsonPropertyName("tabItem")]
        public string TabItem;

        [JsonPropertyName("tabContentItem")]
        public string TabContentItem;

        [JsonPropertyName("accordion")]
        public string Accordion;

        [JsonPropertyName("accordionItem")]
        public string AccordionItem;

        [JsonPropertyName("headings")]
        public Headings Headings;
    }

    public class Popover
    {
        [JsonPropertyName("attr")]
        public string Attr;
    }

    public class Responsive
    {
        [JsonPropertyName("mobile")]
        public int Mobile;

        [JsonPropertyName("tablet")]
        public int Tablet;

        [JsonPropertyName("desktop")]
        public int Desktop;
    }

    public class ProjectSettings
    {
        [JsonPropertyName("typeList")]
        public List<string> TypeList;

        [JsonPropertyName("tagList")]
        public List<string> TagList;

        [JsonPropertyName("sizeList")]
        public List<string> SizeList;

        [JsonPropertyName("dataTypes")]
        public List<string> DataTypes;

        [JsonPropertyName("theme")]
        public Theme Theme;

        [JsonPropertyName("htmlTemplates")]
        public List<HtmlTemplate> HtmlTemplates;

        [JsonPropertyName("pageTemplates")]
        public PageTemplates PageTemplates;

        [JsonPropertyName("inputProperty")]
        public List<InputProperty> InputProperty;

        [JsonPropertyName("pages")]
        public List<Pages> Pages;

        [JsonPropertyName("icons")]
        public Icons Icons;

        [JsonPropertyName("tableSettings")]
        public TableSettings TableSettings;

        [JsonPropertyName("appSettings")]
        public AppSettings AppSettings;
    }

    public class ScrollBar
    {
        [JsonPropertyName("localStorage")]
        public string LocalStorage;

        [JsonPropertyName("dom")]
        public string Dom;

        [JsonPropertyName("attr")]
        public string Attr;

        [JsonPropertyName("skipMobileAttr")]
        public string SkipMobileAttr;

        [JsonPropertyName("heightAttr")]
        public string HeightAttr;

        [JsonPropertyName("wheelPropagationAttr")]
        public string WheelPropagationAttr;
    }

    public class ScrollTo
    {
        [JsonPropertyName("attr")]
        public string Attr;

        [JsonPropertyName("target")]
        public string Target;

        [JsonPropertyName("linkTarget")]
        public string LinkTarget;
    }

    public class ScrollToTopBtn
    {
        [JsonPropertyName("showClass")]
        public string ShowClass;

        [JsonPropertyName("heightShow")]
        public int HeightShow;

        [JsonPropertyName("toggleAttr")]
        public string ToggleAttr;

        [JsonPropertyName("scrollSpeed")]
        public int ScrollSpeed;
    }

    public class Search
    {
        [JsonPropertyName("class")]
        public string Class;

        [JsonPropertyName("toggleAttr")]
        public string ToggleAttr;

        [JsonPropertyName("hideClass")]
        public string HideClass;

        [JsonPropertyName("foundClass")]
        public string FoundClass;
    }

    public class Sidebar
    {
        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("class")]
        public string Class;

        [JsonPropertyName("scrollBar")]
        public ScrollBar ScrollBar;

        [JsonPropertyName("menu")]
        public Menu Menu;

        [JsonPropertyName("mobile")]
        public Mobile Mobile;

        [JsonPropertyName("minify")]
        public Minify Minify;

        [JsonPropertyName("floatSubmenu")]
        public FloatSubmenu FloatSubmenu;

        [JsonPropertyName("search")]
        public Search Search;

        [JsonPropertyName("transparent")]
        public Transparent Transparent;
    }

    public class SidebarEnd
    {
        [JsonPropertyName("class")]
        public string Class;
    }

    public class SidebarLight
    {
        [JsonPropertyName("class")]
        public string Class;
    }

    public class SidebarMinified
    {
        [JsonPropertyName("class")]
        public string Class;
    }

    public class SidebarTwo
    {
        [JsonPropertyName("class")]
        public string Class;
    }

    public class SidebarWide
    {
        [JsonPropertyName("class")]
        public string Class;
    }

    public class Submenu
    {
        [JsonPropertyName("class")]
        public string Class;
    }

    public class TableSettings
    {
        [JsonPropertyName("feedback_url")]
        public string FeedbackUrl;

        [JsonPropertyName("position")]
        public string Position;

        [JsonPropertyName("jQueryUI")]
        public bool JQueryUI;

        [JsonPropertyName("bootstrap")]
        public bool Bootstrap;

        [JsonPropertyName("show_email")]
        public bool ShowEmail;

        [JsonPropertyName("show_radio_button_list")]
        public bool ShowRadioButtonList;

        [JsonPropertyName("close_on_click_outisde")]
        public bool CloseOnClickOutisde;

        [JsonPropertyName("name_label")]
        public string NameLabel;

        [JsonPropertyName("email_label")]
        public string EmailLabel;

        [JsonPropertyName("message_label")]
        public string MessageLabel;

        [JsonPropertyName("radio_button_list_labels")]
        public List<string> RadioButtonListLabels;

        [JsonPropertyName("radio_button_list_title")]
        public string RadioButtonListTitle;

        [JsonPropertyName("name_placeholder")]
        public string NamePlaceholder;

        [JsonPropertyName("email_placeholder")]
        public string EmailPlaceholder;

        [JsonPropertyName("message_placeholder")]
        public string MessagePlaceholder;

        [JsonPropertyName("name_required")]
        public bool NameRequired;

        [JsonPropertyName("email_required")]
        public bool EmailRequired;

        [JsonPropertyName("message_required")]
        public bool MessageRequired;

        [JsonPropertyName("radio_button_list_required")]
        public bool RadioButtonListRequired;

        [JsonPropertyName("show_asterisk_for_required")]
        public bool ShowAsteriskForRequired;

        [JsonPropertyName("submit_label")]
        public string SubmitLabel;

        [JsonPropertyName("title_label")]
        public string TitleLabel;

        [JsonPropertyName("trigger_label")]
        public string TriggerLabel;

        [JsonPropertyName("custom_params")]
        public CustomParams CustomParams;

        [JsonPropertyName("iframe_url")]
        public string IframeUrl;

        [JsonPropertyName("show_form")]
        public bool ShowForm;

        [JsonPropertyName("custom_html")]
        public string CustomHtml;

        [JsonPropertyName("delayed_close")]
        public bool DelayedClose;

        [JsonPropertyName("delayed_options")]
        public DelayedOptions DelayedOptions;
    }

    public class Tabs
    {
        [JsonPropertyName("class")]
        public string Class;

        [JsonPropertyName("activeClass")]
        public string ActiveClass;

        [JsonPropertyName("itemClass")]
        public string ItemClass;

        [JsonPropertyName("itemLinkClass")]
        public string ItemLinkClass;
    }

    public class Theme
    {
        [JsonPropertyName("color")]
        public List<string> Color;

        [JsonPropertyName("style")]
        public List<string> Style;

        [JsonPropertyName("aligner")]
        public List<Aligner> Aligner;

        [JsonPropertyName("animations")]
        public List<Animation> Animations;

        [JsonPropertyName("toggleAttr")]
        public string ToggleAttr;

        [JsonPropertyName("classAttr")]
        public string ClassAttr;

        [JsonPropertyName("cookieName")]
        public string CookieName;

        [JsonPropertyName("activeClass")]
        public string ActiveClass;
    }

    public class ThemeCover
    {
        [JsonPropertyName("toggleAttr")]
        public string ToggleAttr;

        [JsonPropertyName("classAttr")]
        public string ClassAttr;

        [JsonPropertyName("cookieName")]
        public string CookieName;

        [JsonPropertyName("activeClass")]
        public string ActiveClass;
    }

    public class ThemePanel
    {
        [JsonPropertyName("class")]
        public string Class;

        [JsonPropertyName("toggleAttr")]
        public string ToggleAttr;

        [JsonPropertyName("cookieName")]
        public string CookieName;

        [JsonPropertyName("activeClass")]
        public string ActiveClass;

        [JsonPropertyName("themeListCLass")]
        public string ThemeListCLass;

        [JsonPropertyName("themeListItemCLass")]
        public string ThemeListItemCLass;

        [JsonPropertyName("themeCoverClass")]
        public string ThemeCoverClass;

        [JsonPropertyName("themeCoverItemClass")]
        public string ThemeCoverItemClass;

        [JsonPropertyName("theme")]
        public Theme Theme;

        [JsonPropertyName("themeCover")]
        public ThemeCover ThemeCover;
    }

    public class ToggleClass
    {
        [JsonPropertyName("toggleAttr")]
        public string ToggleAttr;

        [JsonPropertyName("targetAttr")]
        public string TargetAttr;
    }

    public class Tooltip
    {
        [JsonPropertyName("attr")]
        public string Attr;
    }

    public class TopMenu
    {
        [JsonPropertyName("class")]
        public string Class;
    }

    public class Transparent
    {
        [JsonPropertyName("class")]
        public string Class;
    }

    public class WithoutHeader
    {
        [JsonPropertyName("class")]
        public string Class;
    }

    public class WithoutSidebar
    {
        [JsonPropertyName("class")]
        public string Class;
    }

}

public class ColumnItem
{
    public string length { get; set; }
    public string name { get; set; }
    public string input { get; set; }
    public string type { get; set; }
}
public class TableAndCols
{
    public string table { get; set; }
    public List<SqlColumn> columns { get; set; }
}

public class TabbleColumn
{
    public string table { get; set; }
    public string column { get; set; }
}
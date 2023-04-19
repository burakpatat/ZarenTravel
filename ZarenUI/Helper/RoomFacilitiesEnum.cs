using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;
using ActionExecutingContext = Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext;

namespace ZarenUI.Helper
{
    public enum RoomFacilitiesEnum
    {
        airconditioning,
        tv,
        bathroom,
        mirror,
        telephone,
        towels,
        hairdryer,
        privatebathroom,
        safe,
        toiletries,

    }
    public class RoomFacilities
    {
        private static event Action<RoomFacilitiesEnum, string> eventHit;

        public static string FacilityNames;
        public RoomFacilities()
        {
            eventHit += FacilitiyName;
        }
        public static string SetFaciliities(RoomFacilitiesEnum _roomfacilityState)
        {
            StringBuilder sb = new StringBuilder();
            sb.Replace("&lt;", "<");
            sb.Replace("&gt;", ">");
            sb.Replace("\"", "&quot;");
            string name = "";
            switch (_roomfacilityState)
            {
                case RoomFacilitiesEnum.airconditioning:
                    sb.AppendLine("<i class=\"fa-solid fa-air-conditioner fa-beat\" style=\"color: #ffffff;\"></i>");
                    name = "Air-Conditioning";
                    break;
                case RoomFacilitiesEnum.tv:
                    sb.AppendLine("<i class=\"fa-solid fa-tv-alt fa-beat\" style=\"color: #ffffff;\"></i>");
                    name = "Tv";
                    break;
                case RoomFacilitiesEnum.privatebathroom:
                    sb.AppendLine("<i class=\"fa-solid fa-bath fa-beat\" style=\"color: #ffffff;\"></i>");
                    name = "Bathroom";
                    break;
                case RoomFacilitiesEnum.telephone:
                    sb.AppendLine("<i class=\"fa-solid fa-phone-rotary fa-beat\" style=\"color: #ffffff;\"></i>");
                    name = "Telephone";
                    break;
                case RoomFacilitiesEnum.towels:
                    sb.AppendLine("<i class=\"fa-solid fa-toilet-paper fa-beat\" style=\"color: #ffffff;\"></i>");
                    name = "Towels";
                    break;
            }

            eventHit?.Invoke(_roomfacilityState, name);

            return sb.ToString();

        }
        public void FacilitiyName(RoomFacilitiesEnum _roomfacilityState, string name)
        {
            FacilityNames = name;
        }
    }
    
}

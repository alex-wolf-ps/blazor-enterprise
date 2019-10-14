using System.Collections.Generic;
using System.Threading.Tasks;
using BethanysPieShopHRM.ComponentsLibrary.Map;
using BethanysPieShopHRM.Server.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Server.Pages
{
    public class EmployeeDetailBase : ComponentBase
    {
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        [Parameter]
        public string EmployeeId { get; set; }

        public List<Marker> MapMarkers { get; set; }

        static Marker ToMapMarker(string description, LatLong coords, bool showPopup = false)
            => new Marker { Description = description, X = coords.Longitude, Y = coords.Latitude, ShowPopup = showPopup };

        public Employee Employee { get; set; } = new Employee();

        public EmployeeDetailBase()
        {
            MapMarkers = new List<Marker>()
            {
                ToMapMarker("You", new LatLong(50.8503, 4.3517), showPopup: true)
            };
        }

        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            
        }
    }

    public class LatLong
    {
        public LatLong()
        {
        }

        public LatLong(double latitude, double longitude) : this()
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public static LatLong Interpolate(LatLong start, LatLong end, double proportion)
        {
            // The Earth is flat, right? So no need for spherical interpolation.
            return new LatLong(
                start.Latitude + (end.Latitude - start.Latitude) * proportion,
                start.Longitude + (end.Longitude - start.Longitude) * proportion);
        }
    }
}

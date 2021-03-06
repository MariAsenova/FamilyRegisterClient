// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace FamilyRegisterClient.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\maria\RiderProjects\FamilyRegisterClient\FamilyRegisterClient\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\maria\RiderProjects\FamilyRegisterClient\FamilyRegisterClient\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\maria\RiderProjects\FamilyRegisterClient\FamilyRegisterClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\maria\RiderProjects\FamilyRegisterClient\FamilyRegisterClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\maria\RiderProjects\FamilyRegisterClient\FamilyRegisterClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\maria\RiderProjects\FamilyRegisterClient\FamilyRegisterClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\maria\RiderProjects\FamilyRegisterClient\FamilyRegisterClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\maria\RiderProjects\FamilyRegisterClient\FamilyRegisterClient\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\maria\RiderProjects\FamilyRegisterClient\FamilyRegisterClient\_Imports.razor"
using FamilyRegisterClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\maria\RiderProjects\FamilyRegisterClient\FamilyRegisterClient\_Imports.razor"
using FamilyRegisterClient.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\maria\RiderProjects\FamilyRegisterClient\FamilyRegisterClient\Pages\AddAdult.razor"
using Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\maria\RiderProjects\FamilyRegisterClient\FamilyRegisterClient\Pages\AddAdult.razor"
using Familyregister.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/AddAdult")]
    public partial class AddAdult : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 30 "C:\Users\maria\RiderProjects\FamilyRegisterClient\FamilyRegisterClient\Pages\AddAdult.razor"
       
    private Adult newAdult = new Adult();
    private Job newJob = new Job();
    private Family familyToAddTo = new Family();
    
    private async Task AddNewAdult()
    {
        IList<Family> families = await FamilyService.GetFamiliesAsync();
        Family familyForNewAdult = families.First(familyToAdd => familyToAdd.HouseNumber == familyToAddTo.HouseNumber && familyToAdd.StreetName.Equals(familyToAddTo.StreetName));
        
        newAdult.JobTitle = newJob;
        await FamilyService.AddAdultAsync(newAdult, familyForNewAdult);
        NavigationManager.NavigateTo("/Adults");
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IFamilyService FamilyService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591

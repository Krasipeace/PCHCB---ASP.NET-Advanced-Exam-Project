﻿namespace PCHCB.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using PCHCB.Services.Data.Contracts;
    using PCHCB.Web.Infrastructure.Extensions;
    using PCHCB.Web.ViewModels.Cooler;
    using PCHCB.Web.ViewModels.Provider;
    using PCHCB.Web.ViewModels.Home;

    using static PCHCB.Common.NotificationMessages;
    using static PCHCB.Common.ErrorMessages.Provider;
    using static PCHCB.Common.ErrorMessages.Cooler;
    using static PCHCB.Common.SuccessMessages;
    using static PCHCB.Common.ExceptionMessages;

    [Authorize]
    public class CoolerController : Controller
    {
        private readonly ICoolerService coolerService;
        private readonly IProviderService providerService;

        public CoolerController(ICoolerService coolerService, IProviderService providerService)
        {
            this.coolerService = coolerService;
            this.providerService = providerService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isProvider = await this.providerService
                .ProviderExistsByUserIdAsync(this.User.GetId()!);

            if (!isProvider)
            {
                this.TempData[ErrorMessage] = UserCannotAddCoolersErrorMessage;

                return this.RedirectToAction("BecomeProvider", "Provider");
            }

            try
            {
                CoolerFormModel model = new CoolerFormModel();

                return this.View(model);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(CoolerFormModel model)
        {
            bool isProvider = await this.providerService
                .ProviderExistsByUserIdAsync(this.User.GetId()!);

            if (!isProvider)
            {
                this.TempData[ErrorMessage] = UserCannotAddCoolersErrorMessage;

                return this.RedirectToAction("BecomeProvider", "Provider");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                string? providerId = await this.providerService
                    .GetProviderByUserIdAsync(this.User.GetId()!);

                int coolerId = await this.coolerService.CreateCoolerAsync(providerId!, model);

                this.TempData[SuccessMessage] = CoolerAddedSuccessfully;

                return this.RedirectToAction("Add", "Cooler", new
                {
                    id = coolerId
                });
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, GeneralErrorMessage);

                return this.View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            bool coolerExists = await coolerService
                .IsCoolerExistByIdAsync(id);
            if (!coolerExists)
            {
                TempData[ErrorMessage] = CoolerWithIdDoesNotExist;

                return RedirectToAction("All", "Cooler");
            }

            bool isUserProvider = await providerService
                .ProviderExistsByUserIdAsync(User.GetId()!);
            if (!isUserProvider)
            {
                TempData[ErrorMessage] = UserCannotEditCoolersErrorMessage;

                return RedirectToAction("BecomeProvider", "Provider");
            }

            string? providerId =
                await providerService.GetProviderByUserIdAsync(User.GetId()!);
            bool isProviderOwner = await coolerService
                .IsProviderIdOwnerOfCoolerIdAsync(providerId!, id);

            if (!isProviderOwner && !User.IsAdmin())
            {
                TempData[ErrorMessage] = ProviderCannotEditCoolerHeDoesNotOwnErrorMessage;

                return RedirectToAction("Mine", "Provider");
            }

            try
            {
                CoolerFormModel formModel = await coolerService
                    .GetCoolerForEditByIdAsync(id);

                return View(formModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CoolerFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool coolerExists = await coolerService
                .IsCoolerExistByIdAsync(id);
            if (!coolerExists)
            {
                TempData[ErrorMessage] = CoolerWithIdDoesNotExist;

                return RedirectToAction("All", "Cooler");
            }

            bool isUserProvider = await providerService
                .ProviderExistsByUserIdAsync(User.GetId()!);
            if (!isUserProvider)
            {
                TempData[ErrorMessage] = UserCannotEditCoolersErrorMessage;

                return RedirectToAction("BecomeProvider", "Provider");
            }

            string? providerId = await providerService
                .GetProviderByUserIdAsync(User.GetId()!);
            bool isProviderOwner = await coolerService
                .IsProviderIdOwnerOfCoolerIdAsync(providerId!, id);

            if (!isProviderOwner && !User.IsAdmin())
            {
                TempData[ErrorMessage] = ProviderCannotEditCoolerHeDoesNotOwnErrorMessage;

                return RedirectToAction("Mine", "Provider");
            }

            try
            {
                await coolerService.EditCoolerByIdAndFormModelAsync(id, model);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty,
                    GeneralErrorMessage);

                return View(model);
            }

            TempData[SuccessMessage] = CoolerEditedSuccessfully;

            return RedirectToAction("Edit", "Cooler", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            bool coolerExists = await coolerService
                .IsCoolerExistByIdAsync(id);
            if (!coolerExists)
            {
                TempData[ErrorMessage] = CoolerWithIdDoesNotExist;

                return RedirectToAction("All", "Cooler");
            }

            bool isUserProvider = await providerService
                .ProviderExistsByUserIdAsync(User.GetId()!);
            if (!isUserProvider)
            {
                TempData[ErrorMessage] = UserCannotDeleteCoolersErrorMessage;

                return RedirectToAction("BecomeProvider", "Provider");
            }

            string? providerId =
                await providerService.GetProviderByUserIdAsync(User.GetId()!);
            bool isProviderOwner = await coolerService
                .IsProviderIdOwnerOfCoolerIdAsync(providerId!, id);
            if (!isProviderOwner && !User.IsAdmin())
            {
                TempData[ErrorMessage] = ProviderCannotDeleteCoolerHeDoesNotOwnErrorMessage;

                return RedirectToAction("Mine", "Provider");
            }

            try
            {
                DeleteDetailsViewModel viewModel =
                    await coolerService.GetCoolerForDeleteByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, DeleteDetailsViewModel model)
        {
            bool coolerExists = await coolerService
                .IsCoolerExistByIdAsync(id);
            if (!coolerExists)
            {
                TempData[ErrorMessage] = CoolerWithIdDoesNotExist;

                return RedirectToAction("All", "Cooler");
            }

            bool isUserProvider = await providerService
                .ProviderExistsByUserIdAsync(User.GetId()!);

            if (!isUserProvider)
            {
                TempData[ErrorMessage] = UserCannotDeleteCoolersErrorMessage;

                return RedirectToAction("BecomeProvider", "Provider");
            }

            string? providerId =
                await providerService.GetProviderByUserIdAsync(User.GetId()!);
            bool isProviderOwner = await coolerService
                .IsProviderIdOwnerOfCoolerIdAsync(providerId!, id);

            if (!isProviderOwner && !User.IsAdmin())
            {
                TempData[ErrorMessage] = ProviderCannotDeleteCoolerHeDoesNotOwnErrorMessage;

                return RedirectToAction("All", "Cooler");
            }

            try
            {
                await coolerService.DeleteCoolerByIdAsync(id);

                TempData[WarningMessage] = CoolerDeletedSuccessfully;

                return RedirectToAction("Mine", "Provider");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, string information)
        {
            bool coolerExists = await coolerService
                .IsCoolerExistByIdAsync(id);
            if (!coolerExists)
            {
                TempData[ErrorMessage] = CoolerWithIdDoesNotExist;

                return RedirectToAction("All", "Cooler");
            }

            try
            {
                CoolerDetailsViewModel viewModel = await coolerService
                .GetCoolerDetailsAsync(id);

                if (viewModel.GetUrlInformation() != information)
                {
                    return RedirectToAction("Error", "Home", StatusCode(404));
                }

                return View(viewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllQueryModel queryModel)
        {
            SearchResult serviceModel = await coolerService.SearchCoolersAsync(queryModel);

            queryModel.Coolers = serviceModel.Coolers;
            queryModel.TotalComponents = serviceModel.TotalComponents;

            return View(queryModel);
        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = GeneralErrorMessage;

            return this.RedirectToAction("Index", "Home");
        }
    }
}

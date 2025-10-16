HandlerRequest in this REPR template is served as a wrapper for domain models (business models)
that will later be handled by the services injected to the BusinessHandler.

(*) Reason for this: Prevent too much object creation to handle the logic, in that:
> HandlerRequest [UserLoginRequest] => Hold LoginModel => This model is used directly by IUserAuthService (injected to UserLoginHandler)
- Instead of: RequestDTO => HandlerRequest => Models => Service
- It will be: RequestDTO => HandlerRequest(Models) => Service (Less object creation, less round-trip)

This is applied the same with HandlerResponse. HandlerResponse will be the wrapper of domain models
that will return to the API.
> HandlerResponse [UserLoginResponse] => Hold LoginResponseModel => This model is returned by IUserAuthService after handle login success.
- Instead of: Services => Models => HandlerResponse => ResponseDTO
- It will be: Services => Models <- [wrapped in] -> HandlerResponse => ResponseDTO.

(?) Questions:

(A) When to use the DomainModel (for both Repository & Services), and when to use specific
ServiceModel.
> If the logic only depend in-app model definition to handle, can use the DomainModel directly for Services & Repositories to resolve.
> If the logic need 3rd-party model definition to handle, the create the related ServiceModel to resolve.

(B) What class will decide the app-code to know the error.
> The app-code should only be defined by the handler (or class that has same responsibility)
> Reason: The service only need to care for handling the business logic, but the error return by services will be capture by handlers and summarize as the app-code and return to clients.
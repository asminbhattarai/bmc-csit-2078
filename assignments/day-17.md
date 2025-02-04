# Day 17 - 2nd Feb, 2025

## Write about:

### Session Methods
> #### builder.Services.AddSession(options => {....})
> #### HttpContext.Session -> get and set
> #### Other methods

### Pipelines in MVC Architecture

### ViewBag, ViewData and TempData

### URL Routing and Features

### API Controller

---

## Look up:

### Controller vs API Controller

### Middleware and Pipeline usage in MVC

---

## Steps:

### Setting up sessions

1. Add session service and then, call it in the pipeline.

2. Go to Action and then, add Session.SetString or Session.SetInt32.

3. In another Action, create Session.GetString or Session.GetInt32.

4. Add these session cookies to ViewBag.

5. Display the data using ViewBag in .cshtml (view file).

---

## Code:

`To update`
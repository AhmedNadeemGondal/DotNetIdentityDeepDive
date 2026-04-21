# DotNetIdentityDeepDive

## Purpose
This repository is a comprehensive technical exploration of **ASP.NET Core Identity**. It focuses on the internal mechanics of authentication, authorization, and user management, moving beyond the default scaffolding to understand how identity integrates with the security pipeline.

## Core Pillars

### 1. The Identity Ecosystem
The project deconstructs the key components that manage security:
* **UserManager:** Handling user-related logic such as registration, password hashing, and profile updates.
* **SignInManager:** Managing the authentication flow, including cookie issuance and multi-factor authentication (MFA).
* **RoleManager:** Implementing role-based access control (RBAC) to manage group permissions.

### 2. Authentication vs. Authorization
Explores the distinct layers of the security process:
* **Authentication:** Verifying user identity through cookies, JWTs, or external providers.
* **Authorization:** Restricting access to resources based on Roles, Claims, or custom Policies using the `[Authorize]` attribute.

### 3. Identity Stores and EF Core
Demonstrates how Identity maps to a database:
* **IdentityDbContext:** Customizing the Entity Framework Core context to handle Identity tables.
* **Schema Customization:** Extending default classes (e.g., `IdentityUser` and `IdentityRole`) to include custom properties like `FirstName`, `LastName`, or `DateOfBirth`.

### 4. Security Mechanics
* **Claims-Based Identity:** Utilizing claims to store granular user information (e.g., email, department) within the security token.
* **Token Providers:** Configuring logic for email confirmation, password resets, and two-factor authentication.
* **Password Policy:** Customizing strength requirements and lockout settings to enhance application security.

## Implementation Highlights
* **Manual Integration:** Setting up Identity services without using the "Individual Accounts" template to understand the registration process.
* **Custom Stores:** Implementing user storage logic that deviates from the default EF Core implementation.
* **Middleware Integration:** Understanding where `app.UseAuthentication()` and `app.UseAuthorization()` sit within the request pipeline.

### Credits
Credit to **Frank Liu**. Check out his [video series](https://www.youtube.com/watch?v=sogS0DtejVA) for the original walkthrough.
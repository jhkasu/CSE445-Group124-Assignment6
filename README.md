# CSE445 Group 124 - Assignment 6

ASP.NET Web Application with Forms Security, integrating multiple WCF services.

## Team Members & Roles

| Member | Responsibilities |
|--------|------------------|
| Juho Kim | Staff.aspx, HashLib DLL, Default.aspx integration, WebStrar deployment, Canvas submission |
| [Member 2] | Login.aspx + Web.config Forms Authentication |
| [Member 3] | Member.aspx + Captcha User Control + Sign-up logic |

## Project Structure

CSE445Assignment6/
├── A6WebApp/              ASP.NET Web Application
│   ├── Default.aspx       Public landing page with Service Directory
│   ├── Login.aspx         Forms authentication login page
│   ├── Member.aspx        Member-only page (sign up + member features)
│   ├── Staff.aspx         Staff-only page
│   ├── Web.config         Forms Auth configuration
│   ├── App_Data/
│   │   ├── Member.xml     Stores hashed member credentials
│   │   └── Staff.xml      Stores hashed staff credentials
│   └── Controls/
│       └── Captcha.ascx   Captcha User Control
└── HashLib/               Class Library (DLL)
└── Hasher.cs          SHA256 hashing functions

## HashLib API

```csharp
using HashLib;

string hashed = Hasher.Hash("myPassword");
bool isValid = Hasher.Verify("myPassword", storedHash);
```

## Login.aspx Requirements (Member 2)

- Input fields: Username, Password
- Look up credentials in Member.xml and Staff.xml
- Hash input password with `HashLib.Hasher.Hash()` and compare with stored hash
- On success: `FormsAuthentication.RedirectFromLoginPage(username, false)`
- Configure `<authentication mode="Forms">` in Web.config
- Restrict Member.aspx and Staff.aspx via `<authorization>` rules

## Member.aspx Requirements (Member 3)

- Sign-up form: Username, Password, Email
- Include Captcha User Control (`Controls/Captcha.ascx`)
- Validate captcha before submission
- Hash password before saving to Member.xml
- Member.xml schema:
```xml
  <Users>
    <User>
      <Username>example</Username>
      <PasswordHash>...</PasswordHash>
      <Email>example@asu.edu</Email>
    </User>
  </Users>
```

## Deadlines

- **Monday 11:59 PM** - Push completed work to GitHub
- **Tuesday** - Final integration, WebStrar deployment, Canvas submission

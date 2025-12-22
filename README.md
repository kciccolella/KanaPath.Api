**KanaPath**

KanaPath is a small, API-first web project for learning Japanese **hiragana**.  
It emphasizes explicit behavior, simple rules, and incremental backend design.

**Why This Project Exists**

KanaPath was created to learn how to build a real backend application using **C#** and **ASP.NET Core**.  
The focus is on understanding _why_ design decisions are made, not just how to implement them.  
This project avoids tutorials, hidden defaults, and fabricated origin stories.

**Current Functionality**

KanaPath currently exposes a single endpoint.

GET /api/kana

The endpoint returns hiragana characters and their romaji equivalents based on **explicit query filters**.

**API Rules**

The following rules define the current API contract.

- Responses are always returned as a list
- At least one filter (row or group) must be provided
- Requests with no filters return **400 Bad Request**
- Random selection is unique
- If count exceeds available results, all matching kana are returned

These rules are enforced through integration tests.

**Query Parameters**

| **Parameter** | **Description** |
| --- | --- |
| row | Kana row (e.g. ra, ka) |
| group | Kana group (main, dakuten, combo, all) |
| count | Number of unique kana to return (default: 1) |

**Example Requests**

GET /api/kana?row=ra  
Returns one random kana from the _ra_ row.

GET /api/kana?row=ra&count=5  
Returns all five kana from the _ra_ row.

GET /api/kana?group=dakuten&row=ka  
Returns one random dakuten kana (が, ぎ, ぐ, げ, ご).

GET /api/kana  
Returns **400 Bad Request**.

**Current Data Scope**

- Hiragana only
- In-memory dataset
- Supported groups:
  - main
  - dakuten (ka-row only)
  - combo (reserved)
  - all (union of available groups)

Persistence and user accounts are intentionally not implemented.

**Tech Stack**

- C#
- ASP.NET Core Web API (.NET 8)
- xUnit with Microsoft.AspNetCore.Mvc.Testing
- OpenAPI / Swagger (exploration only)
- Visual Studio 2022

**Running the Project Locally**

- Clone the repository
- Open the solution in **Visual Studio 2022**
- Press **F5** to run the application
- Navigate to /swagger for API exploration
- Use **Test Explorer** to run integration tests

**Project Status**

🚧 **In Progress**

KanaPath prioritizes clarity, explicit intent, and testability over feature completeness.

**Notes**

This documentation reflects **current behavior**, not planned features.  
Changes are documented only when behavior changes.
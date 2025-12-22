# KanaPath

KanaPath is a small web API designed to help users learn Japanese **hiragana**
through simple, game-like interactions.

This project is being built incrementally as a learning-focused **portfolio
application**, with an emphasis on understanding backend fundamentals and
clean project structure.

---

## Why this project exists

I created KanaPath to learn how to build a real backend application from scratch
using **C#** and **ASP.NET Core**.

Rather than following a tutorial step by step, I wanted to work on a project
that:
- Aligns with my personal interests (language learning and games)
- Encourages learning concepts gradually instead of all at once
- Can evolve over time into a more complete, full-stack application

The long-term vision is to turn KanaPath into a small learning game that uses
repetition and progress tracking to help users memorize Japanese kana.

---

## Current functionality

At its current stage, KanaPath is intentionally simple.

The API currently provides:
- A single endpoint that returns a small set of hiragana characters and their
  romaji equivalents

This version uses **in-memory data** so that the focus remains on learning:
- API routing
- Controllers
- Models
- JSON responses

More advanced features such as persistence, authentication, and a frontend
will be added in later phases.

---

## Tech stack

- C#
- ASP.NET Core Web API (.NET 8)
- OpenAPI / Swagger (for API testing)
- Visual Studio 2022

---

## How to run the project locally

1. Clone the repository
2. Open the solution in **Visual Studio 2022**
3. Press **F5** to run the application
4. When the browser opens, navigate to `/swagger`
5. Use the **GET /api/kana** endpoint to test the API

---

## Project status

🚧 **In progress**

KanaPath is being developed incrementally as part of a learning and
portfolio-building process. Early design decisions favor clarity and
simplicity over completeness.

---

## Notes

This README will evolve as new features are added and as architectural
decisions are made. Major changes will be documented to explain what was
learned and why certain approaches were chosen.

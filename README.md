# Project Manager

מערכת Web API לניהול פרויקטים ומשימות, פותחה כפרויקט סיום לקורס ASP.NET Core.

**מאגר GitHub:** https://github.com/Rivka-Weinstock/Project-Manager

---

## תיאור המערכת

המערכת מאפשרת ניהול משתמשים, פרויקטים, משימות וסטטוסים. כל משתמש יכול להחזיק במספר פרויקטים, וכל פרויקט מכיל משימות עם סטטוס (למשל: To Do, In Progress, Done).

ה-API מספק פעולות CRUD מלאות על ארבע הישויות, עם מיפוי DTOs, טיפול מרכזי בשגיאות ותיעוד Swagger בסביבת פיתוח.

---

## דרישות מקדימות

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [MySQL 8.0](https://dev.mysql.com/downloads/) (מקומי או בענן)

---

## התקנה והרצה

### 1. שכפול המאגר

```bash
git clone https://github.com/Rivka-Weinstock/Project-Manager.git
cd Project-Manager

```

### 2. הגדרת Connection String

ערכי ברירת המחדל נמצאים ב-`Api/appsettings.json`. עדכני את הסיסמה של MySQL:

```json
"DefaultConnection": "Server=localhost;Port=3306;Database=ProjectManagement;User=root;Password=YOUR_PASSWORD;"
```

> **טיפ:** ניתן ליצור קובץ `Api/appsettings.Development.json` עם הסיסמה האישית שלך. הקובץ אינו נשמר ב-Git.

### 3. יצירת בסיס הנתונים

בחרי **אחת** משתי הדרכים:

#### א. סקריפט SQL (מומלץ להגשה)

```bash
mysql -u root -p < DB/CreateDatabase.sql
```

או דרך MySQL Workbench: פתיחת `DB/CreateDatabase.sql` והרצה.

הסקריפט יוצר את הטבלאות, נתוני דמו, ורשומת migration עבור EF Core.

#### ב. Entity Framework Migrations

```bash
dotnet ef database update --project DataAccess --startup-project Api
```

### 4. הרצת ה-API

```bash
dotnet run --project Api
```

ה-API יעלה בכתובת: **http://localhost:5030**

Swagger (Development): **http://localhost:5030/swagger**

---

## ישויות מרכזיות

| ישות | תיאור | שדות עיקריים |
|------|--------|--------------|
| **User** | משתמש במערכת | Name, Email |
| **Project** | פרויקט השייך למשתמש | Name, Description, UserId |
| **TaskItem** | משימה בתוך פרויקט | Title, Description, DueDate, ProjectId, StatusId |
| **Status** | סטטוס משימה | Name |

### קשרים בין הישויות

```
User (1) ──< (N) Project (1) ──< (N) TaskItem (N) >── (1) Status
```

- משתמש → פרויקטים: **One-to-Many**
- פרויקט → משימות: **One-to-Many** (מחיקת פרויקט מוחקת את המשימות שלו)
- סטטוס → משימות: **One-to-Many** (לא ניתן למחוק סטטוס שיש לו משימות)

---

## מבנה השכבות

```
Api              → Controllers, Middleware, Swagger, AutoMapper Profile
BusinessLogic    → Services (לוגיקה עסקית, מיפוי DTO ↔ Entity)
DataAccess       → Repositories, DbContext, EF Core Migrations
Models           → Entities ו-DTOs משותפים
```

**זרימת בקשה:**

```
Client → Controller → Service → Repository → DbContext → MySQL
```

- **Api** — קליטת בקשות HTTP, validation בסיסי, החזרת קודי סטטוס
- **BusinessLogic** — orchestration ו-AutoMapper
- **DataAccess** — גישה יחידה למסד הנתונים (Repository Pattern)
- **Models** — מודלים משותפים ללא תלות בשכבות עליונות

---

## Endpoints

| Resource | Base Route |
|----------|------------|
| Users | `/api/users` |
| Projects | `/api/projects` |
| Tasks | `/api/tasks` |
| Statuses | `/api/statuses` |

כל resource תומך ב-GET (כל / לפי id), POST, PUT, DELETE.

---

## בדיקות API (Swagger)

1. הריצי: `dotnet run --project Api`
2. פתחי: http://localhost:5030/swagger
3. בחרי endpoint → **Try it out** → **Execute**
4. קודי סטטוס צפויים: 200 (GET), 201 (POST), 204 (PUT/DELETE), 404 (לא נמצא), 400 (שגיאת קלט)

---

## מבנה תיקיות

```
Project-Manager/
├── Api/                 # Web API
├── BusinessLogic/       # Services
├── DataAccess/          # Repositories, DbContext, Migrations
├── Models/              # Entities, DTOs
├── DB/                  # סקריפט יצירת בסיס הנתונים
└── ProjectManagement.sln
```

---

## טכנולוגיות

- ASP.NET Core 8 Web API
- Entity Framework Core 8 + Pomelo (MySQL)
- AutoMapper 12
- Swashbuckle (Swagger)

# Бэкенд

- Авторизация через Яндекс/VK
- Базовый чат: Поддержка текста на вход и выход
  - Провайдер: OpenRouter
  - Выбор модели: Модель из предзагатовленного списка
  - Хранение данных: сообщения и чаты (для каждого пользователя)
  - Суммаризация чата из первого сообщения

## Схема БД

```mermaid
erDiagram
    Users ||--o{ Conversation : "creates"
    Users ||--o| UserPreference : "has"
    Conversation ||--o{ Message : "contains"
    Conversation }o--|| ModelInfo : "uses"
    
    Users {
        int Id PK
        string YandexId
        string Email
        string Name
        bool IsActive
        datetime CreatedAt
        datetime UpdatedAt
    }
    
    ModelInfo {
        int Id PK
        string Key
        string DisplayName
        string ContextWindow
        decimal PriceInputPer1K
        decimal PriceOutputPer1K
        bool Enabled
        datetime UpdatedAt
    }
    
    Conversation {
        int Id PK
        int UserId FK
        string Title
        string Model
        datetime CreatedAt
        datetime UpdatedAt
    }
    
    Message {
        int Id PK
        int ConversationId FK
        string Role
        string Content
        string Model
        int PromptTokens
        int CompletionTokens
        datetime CreatedAt
    }
    
    UserPreference {
        int UserId PK
        string DefaultModel
        string Theme
        bool StreamByDefault
        bool StreamPromptDefault
    }
```

## Стек

- .NET 9 Web API
- PostgreSQL + EF Core (Npgsql)
- Auth: Yandex OAuth 
- Кэш: Redis 
- Логирование: Serilog и Seq
- HTTP: HttpClientFactory (OpenRouter)
- Возможный Nginx

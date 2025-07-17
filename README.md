
## Workflow Engine (Minimal State Machine in .NET)

This is a simple state machine engine built using ASP.NET Core. It allows defining workflows (states and transitions), starting workflow instances, executing actions, and tracking the workflow's current state. This project can be extended for business workflows, approval systems, and automation processes.

---

## Features

* Create and store workflow definitions.
* Start and execute workflow instances.
* Track current state of each workflow instance.
* REST API support for all operations.

---

## Prerequisites

* [.NET 6 SDK](https://dotnet.microsoft.com/download)

---

## Getting Started

### Step 1: Clone the Repository

```bash
git clone https://github.com/Ananya-m0140/WorkflowEngine
cd WorkflowEngine
```

### Step 2: Build and Run

```bash
dotnet clean
dotnet build
dotnet run
```

---

## API Testing Using Postman

### 1. Create Workflow Definition

**Endpoint:**

```http
POST http://localhost:5000/WorkflowDefinitions
```

**Request Body:**

```json
{
  "id": "flow1",
  "states": [
    {
      "id": "start",
      "name": "Start",
      "isInitial": true,
      "isFinal": false,
      "enabled": true
    },
    {
      "id": "end",
      "name": "End",
      "isInitial": false,
      "isFinal": true,
      "enabled": true
    }
  ],
  "actions": []
}
```

---

### 2. Get All Workflow Definitions

```http
GET http://localhost:5000/WorkflowDefinitions
```

---

### 3. Get Workflow Definition by ID

```http
GET http://localhost:5000/WorkflowDefinitions/flow1
```
<img width="600" height="479" alt="Screenshot 2025-07-17 200322" src="https://github.com/user-attachments/assets/a907b41c-d09e-4282-8e6f-326e327c02c1" />

---

### 4. Create Workflow Instance

```http
POST http://localhost:5000/WorkflowInstances?definitionId=flow1
```
<img width="600" height="479" alt="Screenshot 2025-07-17 200346" src="https://github.com/user-attachments/assets/2304ed21-0292-4fec-b128-66c8d1b79f9d" />


---

### 5. Execute Workflow Instance

```http
POST http://localhost:5000/WorkflowInstances/{instanceId}/execute
```

Replace `{instanceId}` with the actual instance ID received from the instance creation response.

---

### 6. Get All Workflow Instances

```http
GET http://localhost:5000/WorkflowInstances
```

---



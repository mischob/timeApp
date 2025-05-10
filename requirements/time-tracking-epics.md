# Time Tracking System - EPICs and Project Plan

## EPICs Overview

### EPIC-1: Authentication Setup
**Headline:** "User Login with Azure B2C"

**Description:** Set up Azure AD B2C authentication for the time tracking application.

**Scope:**
- Configure Azure AD B2C tenant and policies
- Implement authentication middleware in API
- Create login/logout flows in Blazor WebAssembly
- Set up authorization attributes on API endpoints
- Handle token refresh and session management

**Technical Details:**
- Technologies: Azure AD B2C, OAuth 2.0/OIDC, JWT
- Components: AuthenticationService, Program.cs configuration
- Dependencies: Microsoft.Identity.Web package

**Acceptance Criteria:**
- Users can sign in using Azure B2C
- Unauthorized users are redirected to login
- Tokens are properly refreshed
- API endpoints are secured

**Estimated Effort:** 5 days

---

### EPIC-2: Time Entry Core Features
**Headline:** "Start/Stop Timer & Manual Entry"

**Description:** Implement core time tracking functionality with start/stop timer and manual time entry capabilities.

**Scope:**
- Create start/stop timer component with real-time display
- Implement manual time entry form with date/time pickers
- Add validation for time entries (German format)
- Handle timezone (Berlin) automatically
- Save entries to appropriate storage (online/offline)

**Technical Details:**
- Technologies: Blazor Components, C#
- Components: TimeEntryComponent, TimeEntryService
- Data Models: TimeEntry class

**Example:**
```csharp
// Timer running display: "08:15:30"
// Manual entry form accepts: "13.04.2024" and "14:30"
```

**Acceptance Criteria:**
- Timer starts/stops and displays current duration
- Manual entries can be created for past dates
- All times are handled in Berlin timezone
- Proper validation prevents invalid entries

**Estimated Effort:** 8 days

---

### EPIC-3: Offline Storage & Sync
**Headline:** "Work Offline & Auto-Sync"

**Description:** Implement offline capabilities using SQLite and automatic synchronization with SQL Server.

**Scope:**
- Set up SQLite database in browser (IndexedDB via JS Interop)
- Create sync service for background synchronization
- Handle conflict resolution for offline changes
- Implement online/offline detection
- Queue offline changes for later sync

**Technical Details:**
- Technologies: SQLite, IndexedDB, JS Interop
- Components: OfflineStorageService, SyncService
- Services: BackgroundService for periodic sync

**Example:**
```javascript
// IndexedDB structure
{
  timeEntries: [
    { id: "...", syncStatus: "Pending", ... }
  ]
}
```

**Acceptance Criteria:**
- App works completely offline
- Changes sync automatically when online
- No data loss during offline/online transitions
- Sync status is visible to users

**Estimated Effort:** 10 days

---

### EPIC-4: Database & API Setup
**Headline:** "Backend API & Database"

**Description:** Set up SQL Server database and create RESTful/OData APIs for time entry management.

**Scope:**
- Create SQL Server database schema
- Implement REST API endpoints for CRUD operations
- Add OData endpoint for advanced querying
- Set up Entity Framework Core
- Create database migrations

**Technical Details:**
- Technologies: SQL Server, ASP.NET Core Web API, Entity Framework Core
- Endpoints: /api/v1/timeentries, /odata/v1/TimeEntries
- Database: TimeEntries table with indexes

**Example API Endpoints:**
```
POST /api/v1/timeentries
GET /api/v1/timeentries?startDate=2024-01-01
GET /odata/v1/TimeEntries?$filter=UserId eq '123'
```

**Acceptance Criteria:**
- All CRUD operations work via API
- OData queries support filtering and sorting
- Database properly indexed for performance
- API responses follow REST standards

**Estimated Effort:** 6 days

---

### EPIC-5: Overtime & Dashboard
**Headline:** "Hours Dashboard with Overtime"

**Description:** Create dashboard showing weekly, monthly, and yearly hours with overtime calculations.

**Scope:**
- Build dashboard component with period selection
- Calculate overtime based on 16-hour weekly target
- Display under/overtime for different periods
- Create visual indicators for overtime status
- Implement summary calculations

**Technical Details:**
- Technologies: Blazor Components, Chart.js (optional)
- Components: DashboardComponent, OvertimeCalculator
- API: /api/v1/timeentries/summary endpoint

**Example Display:**
```
This Week: 18.5h / 16h (Overtime: +2.5h)
This Month: 65h / 64h (Overtime: +1h)
This Year: 780h / 832h (Undertime: -52h)
```

**Acceptance Criteria:**
- Dashboard shows accurate hour calculations
- Overtime/undertime clearly displayed
- Period selection works (week/month/year)
- Data updates when new entries added

**Estimated Effort:** 5 days

---

### EPIC-6: Excel Export
**Headline:** "Export Reports to Excel"

**Description:** Implement Excel export functionality with Azure Blob Storage integration.

**Scope:**
- Create Excel export service using EPPlus/ClosedXML
- Generate formatted Excel files with time entries
- Upload exports to Azure Blob Storage
- Generate secure download links (SAS tokens)
- Add export UI with date range selection

**Technical Details:**
- Technologies: EPPlus, Azure Blob Storage, SAS tokens
- Components: ExportComponent, ExportService
- Storage: Azure Blob container "timetracking"

**Example Export Format:**
| Date | Start Time | End Time | Duration (Hours) |
|------|------------|----------|------------------|
| 13.04.2024 | 09:00 | 17:30 | 8.5 |
| 14.04.2024 | 08:30 | 16:00 | 7.5 |
| **Total Hours:** | | | **16.0** |

**Acceptance Criteria:**
- Excel files contain all time entries
- Proper formatting with German date/time
- Secure download links expire after 1 hour
- Export includes summary totals

**Estimated Effort:** 4 days

---

### EPIC-7: Responsive UI Design
**Headline:** "Mobile & Desktop Views"

**Description:** Create responsive UI that adapts between mobile and desktop layouts.

**Scope:**
- Design mobile-optimized layout for quick access
- Create desktop layout with better overview
- Implement responsive CSS/Bootstrap
- Test on various devices and browsers
- Ensure touch-friendly mobile interface

**Technical Details:**
- Technologies: Blazor, Bootstrap/CSS, Media Queries
- Components: ResponsiveLayout, MobileNav, DesktopNav
- Browser Support: Chrome, Safari, Firefox on iOS/Android

**Example Breakpoints:**
```css
/* Mobile */
@media (max-width: 768px) {
  .time-entry-container.mobile { /* Simplified layout */ }
}

/* Desktop */
@media (min-width: 769px) {
  .time-entry-container.desktop { /* Full features */ }
}
```

**Acceptance Criteria:**
- UI works on iPhone and Android devices
- Desktop provides enhanced overview
- Navigation adapts to screen size
- All features accessible on both layouts

**Estimated Effort:** 6 days

---

### EPIC-8: PWA Configuration
**Headline:** "Make It Installable"

**Description:** Configure Progressive Web App features for offline capability and installation.

**Scope:**
- Create PWA manifest file
- Implement service worker for offline caching
- Add install prompts for mobile/desktop
- Configure offline fallback pages
- Test installation process

**Technical Details:**
- Technologies: Service Workers, Web App Manifest
- Files: manifest.json, service-worker.js
- Caching: Static assets and API responses

**Acceptance Criteria:**
- App can be installed on home screen
- Works offline after installation
- Updates available when online
- Icons and splash screens configured

**Estimated Effort:** 3 days

---

### EPIC-9: Time Entry Management
**Headline:** "Edit & Fix Time Entries"

**Description:** Implement editing functionality for existing time entries with overlap handling.

**Scope:**
- Create edit form for existing entries
- Implement overlap detection algorithm
- Handle midnight-crossing time entries
- Add visual warnings for overlaps
- Ensure proper time calculations

**Technical Details:**
- Technologies: Blazor Forms, Validation
- Components: TimeEntryEditComponent
- Services: OverlapDetectionService

**Example Overlap Handling:**
```
Entry 1: 09:00-12:00 (3h)
Entry 2: 11:00-13:00 (2h)
Total: 4h (not 5h, overlap excluded)
```

**Acceptance Criteria:**
- Users can edit past entries
- Overlaps are detected and handled
- Visual warnings shown for overlaps
- Midnight entries split correctly

**Estimated Effort:** 5 days

---

### EPIC-10: Testing & Documentation
**Headline:** "Test Everything & Document"

**Description:** Comprehensive testing and documentation for the system.

**Scope:**
- Write unit tests for services
- Create integration tests for API
- Test offline/online scenarios
- Document API endpoints
- Create user guide
- Set up CI/CD pipeline

**Technical Details:**
- Technologies: xUnit, Moq, Azure DevOps
- Documentation: OpenAPI/Swagger, Markdown
- Testing: Unit, Integration, E2E tests

**Acceptance Criteria:**
- 80% code coverage
- All critical paths tested
- API documentation complete
- User guide available
- CI/CD pipeline working

**Estimated Effort:** 8 days

---

## Project Timeline

### Phase 1: Foundation (Weeks 1-2)
- EPIC-1: Authentication Setup (5 days)
- EPIC-4: Database & API Setup (6 days)

### Phase 2: Core Features (Weeks 3-4)
- EPIC-2: Time Entry Core Features (8 days)
- EPIC-7: Responsive UI Design (6 days)

### Phase 3: Advanced Features (Weeks 5-6)
- EPIC-3: Offline Storage & Sync (10 days)
- EPIC-8: PWA Configuration (3 days)

### Phase 4: Data & Reporting (Weeks 7-8)
- EPIC-5: Overtime & Dashboard (5 days)
- EPIC-6: Excel Export (4 days)
- EPIC-9: Time Entry Management (5 days)

### Phase 5: Quality Assurance (Week 9)
- EPIC-10: Testing & Documentation (8 days)

**Total Duration: 9 weeks**

## Resource Estimation

### Team Composition
Based on the project scope and timeline, the recommended team composition is:

**2 Full-Stack Developers**
- 1 Senior Developer (Lead)
- 1 Mid-Level Developer

**AI Assistant Role:**
- Code generation for standard components
- API endpoint scaffolding
- Test case generation
- Documentation assistance
- Code review support

### Justification:
1. **Why 2 developers:**
   - Complex offline/online synchronization requires careful implementation
   - Parallel work on frontend/backend components
   - Knowledge sharing and code review capabilities
   - Reduced risk if one developer is unavailable

2. **AI Contribution:**
   - Reduces boilerplate code writing by ~40%
   - Accelerates test writing and documentation
   - Provides instant code reviews and best practices
   - Helps with troubleshooting and debugging

3. **Timeline Considerations:**
   - 9-week timeline is aggressive but achievable with AI assistance
   - Critical path includes offline sync (EPIC-3) and core features (EPIC-2)
   - Testing phase can be accelerated with AI-generated test cases

### Risk Mitigation:
- Add 1 week buffer for unexpected issues
- Consider part-time QA resource for final testing phase
- Plan for knowledge transfer sessions between developers
- Maintain detailed documentation throughout development

### Success Factors:
1. Clear requirements (already provided)
2. Experienced developers familiar with the tech stack
3. Effective use of AI for routine tasks
4. Regular progress reviews and adjustments
5. Good communication between team members

This team size balances efficiency with risk management while leveraging AI to accelerate development.

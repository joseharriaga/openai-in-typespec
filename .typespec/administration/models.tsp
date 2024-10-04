/*
 * This file was automatically generated from an OpenAPI .yaml file.
 * Edits made directly to this file will be lost.
 */

using TypeSpec.OpenAPI;

namespace OpenAI;

/** The service account that performed the audit logged action. */
model AuditLogActorServiceAccount {
  /** The service account id. */
  id?: string;
}

/** The user who performed the audit logged action. */
model AuditLogActorUser {
  /** The user id. */
  id?: string;

  /** The user email. */
  email?: string;
}

/** The API Key used to perform the audit logged action. */
model AuditLogActorApiKey {
  /** The tracking id of the API key. */
  id?: string;

  @doc("""
    The type of API key. Can be either `user` or `service_account`.
    """)
  type?: "user" | "service_account";

  user?: AuditLogActorUser;
  service_account?: AuditLogActorServiceAccount;
}

/** The session in which the audit logged action was performed. */
model AuditLogActorSession {
  user?: AuditLogActorUser;

  /** The IP address from which the action was performed. */
  ip_address?: string;
}

/** The actor who performed the audit logged action. */
model AuditLogActor {
  @doc("""
    The type of actor. Is either `session` or `api_key`.
    """)
  type?: "session" | "api_key";

  session?: AuditLogActorSession;
  api_key?: AuditLogActorApiKey;
}

/** The event type. */
@extension("x-oaiExpandable", true)
union AuditLogEventType {
  "api_key.created",
  "api_key.updated",
  "api_key.deleted",
  "invite.sent",
  "invite.accepted",
  "invite.deleted",
  "login.succeeded",
  "login.failed",
  "logout.succeeded",
  "logout.failed",
  "organization.updated",
  "project.created",
  "project.updated",
  "project.archived",
  "service_account.created",
  "service_account.updated",
  "service_account.deleted",
  "user.added",
  "user.updated",
  "user.deleted",
}

/** A log of a user action or configuration change within this organization. */
model AuditLog {
  /** The ID of this log. */
  id: string;

  type: AuditLogEventType;

  // Tool customization: 'created' and fields ending in '_at' are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) of the event. */
  @encode("unixTimestamp", int32)
  effective_at: utcDateTime;

  /** The project that the action was scoped to. Absent for actions not scoped to projects. */
  project?: {
    /** The project ID. */
    id?: string;

    /** The project title. */
    name?: string;
  };

  actor: AuditLogActor;

  @doc("""
    The details for events with this `type`.
    """)
  @encodedName("application/json", "api_key.created")
  api_key_created?: {
    /** The tracking ID of the API key. */
    id?: string;

    /** The payload used to create the API key. */
    data?: {
      @doc("""
        A list of scopes allowed for the API key, e.g. `["api.model.request"]`
        """)
      scopes?: string[];
    };
  };

  @doc("""
    The details for events with this `type`.
    """)
  @encodedName("application/json", "api_key.updated")
  api_key_updated?: {
    /** The tracking ID of the API key. */
    id?: string;

    /** The payload used to update the API key. */
    changes_requested?: {
      @doc("""
        A list of scopes allowed for the API key, e.g. `["api.model.request"]`
        """)
      scopes?: string[];
    };
  };

  @doc("""
    The details for events with this `type`.
    """)
  @encodedName("application/json", "api_key.deleted")
  api_key_deleted?: {
    /** The tracking ID of the API key. */
    id?: string;
  };

  @doc("""
    The details for events with this `type`.
    """)
  @encodedName("application/json", "invite.sent")
  invite_sent?: {
    /** The ID of the invite. */
    id?: string;

    /** The payload used to create the invite. */
    data?: {
      /** The email invited to the organization. */
      email?: string;

      @doc("""
        The role the email was invited to be. Is either `owner` or `member`.
        """)
      role?: string;
    };
  };

  @doc("""
    The details for events with this `type`.
    """)
  @encodedName("application/json", "invite.accepted")
  invite_accepted?: {
    /** The ID of the invite. */
    id?: string;
  };

  @doc("""
    The details for events with this `type`.
    """)
  @encodedName("application/json", "invite.deleted")
  invite_deleted?: {
    /** The ID of the invite. */
    id?: string;
  };

  @doc("""
    The details for events with this `type`.
    """)
  @encodedName("application/json", "login.failed")
  login_failed?: {
    /** The error code of the failure. */
    error_code?: string;

    /** The error message of the failure. */
    error_message?: string;
  };

  @doc("""
    The details for events with this `type`.
    """)
  @encodedName("application/json", "logout.failed")
  logout_failed?: {
    /** The error code of the failure. */
    error_code?: string;

    /** The error message of the failure. */
    error_message?: string;
  };

  @doc("""
    The details for events with this `type`.
    """)
  @encodedName("application/json", "organization.updated")
  organization_updated?: {
    /** The organization ID. */
    id?: string;

    /** The payload used to update the organization settings. */
    changes_requested?: {
      /** The organization title. */
      title?: string;

      /** The organization description. */
      description?: string;

      /** The organization name. */
      name?: string;

      settings?: {
        @doc("""
          Visibility of the threads page which shows messages created with the Assistants API and Playground. One of `ANY_ROLE`, `OWNERS`, or `NONE`.
          """)
        threads_ui_visibility?: string;

        @doc("""
          Visibility of the usage dashboard which shows activity and costs for your organization. One of `ANY_ROLE` or `OWNERS`.
          """)
        usage_dashboard_visibility?: string;
      };
    };
  };

  @doc("""
    The details for events with this `type`.
    """)
  @encodedName("application/json", "project.created")
  project_created?: {
    /** The project ID. */
    id?: string;

    /** The payload used to create the project. */
    data?: {
      /** The project name. */
      name?: string;

      /** The title of the project as seen on the dashboard. */
      title?: string;
    };
  };

  @doc("""
    The details for events with this `type`.
    """)
  @encodedName("application/json", "project.updated")
  project_updated?: {
    /** The project ID. */
    id?: string;

    /** The payload used to update the project. */
    changes_requested?: {
      /** The title of the project as seen on the dashboard. */
      title?: string;
    };
  };

  @doc("""
    The details for events with this `type`.
    """)
  @encodedName("application/json", "project.archived")
  project_archived?: {
    /** The project ID. */
    id?: string;
  };

  @doc("""
    The details for events with this `type`.
    """)
  @encodedName("application/json", "service_account.created")
  service_account_created?: {
    /** The service account ID. */
    id?: string;

    /** The payload used to create the service account. */
    data?: {
      @doc("""
        The role of the service account. Is either `owner` or `member`.
        """)
      role?: string;
    };
  };

  @doc("""
    The details for events with this `type`.
    """)
  @encodedName("application/json", "service_account.updated")
  service_account_updated?: {
    /** The service account ID. */
    id?: string;

    /** The payload used to updated the service account. */
    changes_requested?: {
      @doc("""
        The role of the service account. Is either `owner` or `member`.
        """)
      role?: string;
    };
  };

  @doc("""
    The details for events with this `type`.
    """)
  @encodedName("application/json", "service_account.deleted")
  service_account_deleted?: {
    /** The service account ID. */
    id?: string;
  };

  @doc("""
    The details for events with this `type`.
    """)
  @encodedName("application/json", "user.added")
  user_added?: {
    /** The user ID. */
    id?: string;

    /** The payload used to add the user to the project. */
    data?: {
      @doc("""
        The role of the user. Is either `owner` or `member`.
        """)
      role?: string;
    };
  };

  @doc("""
    The details for events with this `type`.
    """)
  @encodedName("application/json", "user.updated")
  user_updated?: {
    /** The project ID. */
    id?: string;

    /** The payload used to update the user. */
    changes_requested?: {
      @doc("""
        The role of the user. Is either `owner` or `member`.
        """)
      role?: string;
    };
  };

  @doc("""
    The details for events with this `type`.
    """)
  @encodedName("application/json", "user.deleted")
  user_deleted?: {
    /** The user ID. */
    id?: string;
  };
}

model ListAuditLogsResponse {
  object: "list";
  data: AuditLog[];
  first_id: string;
  last_id: string;
  has_more: boolean;
}

@doc("""
  Represents an individual `invite` to the organization.
  """)
model Invite {
  @doc("""
    The object type, which is always `organization.invite`
    """)
  object: "organization.invite";

  /** The identifier, which can be referenced in API endpoints */
  id: string;

  /** The email address of the individual to whom the invite was sent */
  email: string;

  @doc("""
    `owner` or `reader`
    """)
  role: "owner" | "reader";

  @doc("""
    `accepted`,`expired`, or `pending`
    """)
  status: "accepted" | "expired" | "pending";

  // Tool customization: 'created' and fields ending in '_at' are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) of when the invite was sent. */
  @encode("unixTimestamp", int32)
  invited_at: utcDateTime;

  // Tool customization: 'created' and fields ending in '_at' are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) of when the invite expires. */
  @encode("unixTimestamp", int32)
  expires_at: utcDateTime;

  // Tool customization: 'created' and fields ending in '_at' are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) of when the invite was accepted. */
  @encode("unixTimestamp", int32)
  accepted_at?: utcDateTime;
}

model InviteListResponse {
  @doc("""
    The object type, which is always `list`
    """)
  object: "list";

  data: Invite[];

  @doc("""
    The first `invite_id` in the retrieved `list`
    """)
  first_id?: string;

  @doc("""
    The last `invite_id` in the retrieved `list`
    """)
  last_id?: string;

  @doc("""
    The `has_more` property is used for pagination to indicate there are additional results.
    """)
  has_more?: boolean;
}

model InviteRequest {
  /** Send an email to this address */
  email: string;

  @doc("""
    `owner` or `reader`
    """)
  role: "reader" | "owner";
}

model InviteDeleteResponse {
  @doc("""
    The object type, which is always `organization.invite.deleted`
    """)
  object: "organization.invite.deleted";

  id: string;
  deleted: boolean;
}

@doc("""
  Represents an individual `user` within an organization.
  """)
model User {
  @doc("""
    The object type, which is always `organization.user`
    """)
  object: "organization.user";

  /** The identifier, which can be referenced in API endpoints */
  id: string;

  /** The name of the user */
  name: string;

  /** The email address of the user */
  email: string;

  @doc("""
    `owner` or `reader`
    """)
  role: "owner" | "reader";

  // Tool customization: 'created' and fields ending in '_at' are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) of when the user was added. */
  @encode("unixTimestamp", int32)
  added_at: utcDateTime;
}

model UserListResponse {
  object: "list";
  data: User[];
  first_id: string;
  last_id: string;
  has_more: boolean;
}

model UserRoleUpdateRequest {
  @doc("""
    `owner` or `reader`
    """)
  role: "owner" | "reader";
}

model UserDeleteResponse {
  object: "organization.user.deleted";
  id: string;
  deleted: boolean;
}

/** Represents an individual project. */
model Project {
  /** The identifier, which can be referenced in API endpoints */
  id: string;

  @doc("""
    The object type, which is always `organization.project`
    """)
  object: "organization.project";

  /** The name of the project. This appears in reporting. */
  name: string;

  // Tool customization: 'created' and fields ending in '_at' are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) of when the project was created. */
  @encode("unixTimestamp", int32)
  created_at: utcDateTime;

  // Tool customization: 'created' and fields ending in '_at' are Unix encoded utcDateTime
  @doc("""
    The Unix timestamp (in seconds) of when the project was archived or `null`.
    """)
  @encode("unixTimestamp", int32)
  archived_at?: utcDateTime | null;

  @doc("""
    `active` or `archived`
    """)
  status: "active" | "archived";
}

model ProjectListResponse {
  object: "list";
  data: Project[];
  first_id: string;
  last_id: string;
  has_more: boolean;
}

model ProjectCreateRequest {
  /** The friendly name of the project, this name appears in reports. */
  name: string;
}

model ProjectUpdateRequest {
  /** The updated name of the project, this name appears in reports. */
  name: string;
}

model DefaultProjectErrorResponse {
  code: int32;
  message: string;
}

/** Represents an individual user in a project. */
model ProjectUser {
  @doc("""
    The object type, which is always `organization.project.user`
    """)
  object: "organization.project.user";

  /** The identifier, which can be referenced in API endpoints */
  id: string;

  /** The name of the user */
  name: string;

  /** The email address of the user */
  email: string;

  @doc("""
    `owner` or `member`
    """)
  role: "owner" | "member";

  // Tool customization: 'created' and fields ending in '_at' are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) of when the project was added. */
  @encode("unixTimestamp", int32)
  added_at: utcDateTime;
}

model ProjectUserListResponse {
  object: string;
  data: ProjectUser[];
  first_id: string;
  last_id: string;
  has_more: boolean;
}

model ProjectUserCreateRequest {
  /** The ID of the user. */
  user_id: string;

  @doc("""
    `owner` or `member`
    """)
  role: "owner" | "member";
}

model ProjectUserUpdateRequest {
  @doc("""
    `owner` or `member`
    """)
  role: "owner" | "member";
}

model ProjectUserDeleteResponse {
  object: "organization.project.user.deleted";
  id: string;
  deleted: boolean;
}

/** Represents an individual service account in a project. */
model ProjectServiceAccount {
  @doc("""
    The object type, which is always `organization.project.service_account`
    """)
  object: "organization.project.service_account";

  /** The identifier, which can be referenced in API endpoints */
  id: string;

  /** The name of the service account */
  name: string;

  @doc("""
    `owner` or `member`
    """)
  role: "owner" | "member";

  // Tool customization: 'created' and fields ending in '_at' are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) of when the service account was created */
  @encode("unixTimestamp", int32)
  created_at: utcDateTime;
}

model ProjectServiceAccountListResponse {
  object: "list";
  data: ProjectServiceAccount[];
  first_id: string;
  last_id: string;
  has_more: boolean;
}

model ProjectServiceAccountCreateRequest {
  /** The name of the service account being created. */
  name: string;
}

model ProjectServiceAccountCreateResponse {
  object: "organization.project.service_account";
  id: string;
  name: string;

  @doc("""
    Service accounts can only have one role of type `member`
    """)
  role: "member";

  // Tool customization: 'created' and fields ending in '_at' are Unix encoded utcDateTime
  @encode("unixTimestamp", int32)
  created_at: utcDateTime;

  api_key: ProjectServiceAccountApiKey;
}

model ProjectServiceAccountApiKey {
  @doc("""
    The object type, which is always `organization.project.service_account.api_key`
    """)
  object: "organization.project.service_account.api_key";

  value: string;
  name: string;

  // Tool customization: 'created' and fields ending in '_at' are Unix encoded utcDateTime
  @encode("unixTimestamp", int32)
  created_at: utcDateTime;

  id: string;
}

model ProjectServiceAccountDeleteResponse {
  object: "organization.project.service_account.deleted";
  id: string;
  deleted: boolean;
}

/** Represents an individual API key in a project. */
model ProjectApiKey {
  @doc("""
    The object type, which is always `organization.project.api_key`
    """)
  object: "organization.project.api_key";

  /** The redacted value of the API key */
  redacted_value: string;

  /** The name of the API key */
  name: string;

  // Tool customization: 'created' and fields ending in '_at' are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) of when the API key was created */
  @encode("unixTimestamp", int32)
  created_at: utcDateTime;

  /** The identifier, which can be referenced in API endpoints */
  id: string;

  owner: {
    @doc("""
      `user` or `service_account`
      """)
    type?: "user" | "service_account";

    user?: ProjectUser;
    service_account?: ProjectServiceAccount;
  };
}

model ProjectApiKeyListResponse {
  object: "list";
  data: ProjectApiKey[];
  first_id: string;
  last_id: string;
  has_more: boolean;
}

model ProjectApiKeyDeleteResponse {
  object: "organization.project.api_key.deleted";
  id: string;
  deleted: boolean;
}

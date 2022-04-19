# User Management

The following are the requirements for user management system

## User Types

- The **System** must have an `Admin` _user type_.
- The **System** creates its own `Admin` and `Super Administrator` on first deploy.
- The **System** must have dynamic _user types_.
    -   Only the `Admin` and `Super Administrator` user type can create new _user types_.
- The **System** access can be restricted via _user types_.
- The **System** must validate a user has a valid _user type_.
- The **System** validates __user request__ in the backend and not the front end.
- __User Type__ updates can only be done by an `Admin`.
- A __User type__ cannot be deleted, under any circumstances. 
- A __User type__ must have a created date.
- A __User type__ must have a last edited date.
- A __User type__ must have a last created by id.
- A __User type__ must have a last edited by id.

    ### Default User Types
    - `System Administrator`
        - Has full access on the whole system
        - All `System Adminstrator` must have a ___greek god's___ name as a `username`
        - A `System Administrator` must have the following password restrictions.
            - Must have at least one capital case character.
            - Must have at least one lower case character.
            - Must have at least one symbol.
            - Must have at least one number.
            - Must have be atleast 16 characters in length.
            - Must not contain ___greek god's___ name.
            - Password can only be valid for 30days
            - Password must not be a repeat of the last three passwords.
        - There can only be one `System Administrator` in a system
    - `Admin` 
        - Can access the full system
        - Users under the _user type_ `Admin` can only be created by `System Administrators`.
        - Users under the _user type_ `Admin` must be linked to official company domain emails.
        - A `Admin` must have the following password restrictions.
            - Must have at least one capital case character.
            - Must have at least one lower case character.
            - Must have at least one symbol.
            - Must have at least one number.
            - Must have be atleast 16 characters in length.
            - Must not contain the ___admin name___ .
            - Password can only be valid for 30days
            - Password must not be a repeat of the last three passwords.

    ### User Types Mandatory Fields
    - __Name__ - type ___string___
        - Must be unique.
        - Must be at least 4 characters long.
    - __Description__ - type ___string___
        - A good definition of the user type
    - __CreatedBy__ - type ___Guid___
        - Cannot be null, must be linked to a valid `Admin` account 
    - __CreatedDate__ - type ___datetime___
        - Cannot be null
    - __LastEditedBy__ - type ___Guid___
        - Cannot be null, must be linked to a valid `Admin` account
    - __LastEditedDate__ - type ___datetime___
        - Cannot be null
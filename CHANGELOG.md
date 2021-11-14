﻿# Ground Station

## 1.8.0.0 - 2021-11-??
* Housekeeping release; no functional changes
* Reorganized plugin source code and put Ground Station into its on repository
* Minimum supported NINA version is now 2.0 beta 1

## 1.7.5.0 - 2021-11-01
* Fixed issue with URL encoding

## 1.7.0.0 - 2021-10-27
* Updated the settings save routine to use the new safe multi-instance method in 1.11 build 172

## 1.7.0.0 - 2021-10-25
* Fixed corner case that could result in failed error notifications
* Minimum supported NINA version is now 1.11 build 170

## 1.6.0.0 - 2021-10-5
* Added new "Send HTTP Request" instruction for making a generic HTTP GET/POST request to a URL. Message token substitution is supported in the URL and POST body
* Minimum supported NINA version is now 1.11 build 141

## 1.5.5.0 - 2021-9-1
* Fix some corner cases when Failures to... triggers are ran as a Global Trigger

## 1.5.0.0 - 2021-8-13
* Fix null reference when running trigger or action in the root container

## 1.4.2.0 - 2021-8-13
* Small fixes and adjustments to Help tab text formatting

## 1.4.1.0 - 2021-8-9
* Fix missing token substitution for IFTTT failure messages

## 1.4.0.0 - 2021-8-6
* This release reorganizes the Message Tokens Help tab and adds new tokens that may be used:
  * `$$SYSTEM_NAME$$` - The name of the computer
  * `$$USER_NAME$$` - The name of the user running N.I.N.A.
  * `$$NINA_VERSION$$` - The version of N.I.N.A.
  * `$$GS_VERSION$$` - The version of Ground Station
  * `$$FORMAT_DATETIME <custom date and time format>$$` - Custom local date and time string
  * `$$FORMAT_DATETIME_UTC <custom date and time format>$$` - Custom UTC date and time string

 The `$$FORMAT_DATETIME <custom date and time format>$$` token takes additional options in the form of [format specifiers](https://docs.microsoft.com/dotnet/standard/base-types/custom-date-and-time-format-strings). This allows you to insert a custom date and time string into your messages. Simply specify the format specifiers in the indicated area of the token. Your system's cultural settings are observed. For example, `$$FORMAT_DATETIME ddd d MMM$$` will display "Thu 14 Aug" for systems set to US English, and "ven. 14 août" for French locales. Local time is used. To create custom times in UTC, use `$$FORMAT_DATETIME_UTC ...$$` token instead.

## 1.3.0.0 - 2021-8-4
* Fix message failure when a DSO container is not present

## 1.2.0.0 - 2021-8-3
* Added message tokens and customizable failure message text for each service. Please refer to the Message Token Help tab for a list of supported tokens
* MQTT: added a `version` field to the failure JSON object. We start with version `1`
* Uses new `ShouldTriggerAfter()` method to evaluate failure conditions
* Minimum supported NINA version is now 1.11 build 120

## 1.1.0.0 - 2021-8-1
* MQTT: Added instruction and failure trigger for [MQTT](https://mqtt.org/) brokers
* Fixed failure triggers running twice for failed items when used as a Global Trigger
* Moved configuration options to a more compact tabbed layout
* Large refactoring of the Ground Station code to reduce duplication and make it more efficient
* Reordered change log to list the most recent versions first
* Updated MimeKit to 2.14.0
* Minimum supported NINA version is now 1.11 build 116

## 1.0.0.7 - 2021-7-28
* Improved sanitization of configurable inputs
* Added ability to configure a default Pushover sound and message priority for failures and normal messages

## 1.0.0.6 - 2021-7-18
* Added instruction and failure trigger for [Telegram](https://telegram.org/)
* Message text boxes now have vertical and horizontal scrollbars and soft wrapping

## 1.0.0.5 - 2021-7-14
* Added validation issue list to failure messages
  * Pushover, Email: list of any validation issues in the previous instruction is appended to the failure message
  * IFTTT: list of any validation issues in the previous instruction is populated into Value 3 of the Webhooks message
* Fix validation refesh issue in Send to Pushover
* Fix for invalid base64 strings in encrypted credential storage
* Fix instructions displaying as triggers in mini sequencer

## 1.0.0.4 - 2021-7-7 (beta)
* Fix installation issue

## 1.0.0.3 - 2021-7-7 (beta)
* Minimum NINA version: 1.11.0.1106
* Fix the saving of empty encrypted settings
* Ensure that the validator signals an update of any validation issues

## 1.0.0.2 - 2021-7-7 (pre-release)
* Store all passwords and API key settings using the `ProtectedData` class

## 1.0.0.1 - 2021-7-5 (pre-release)
* Initial release
* Added Instructions:
  - Send email
  - Send to Pushover
  - Send to IFTTT
* Added Triggers:
  - Failures to email
  - Failures to Pushover
  - Failures to IFTTT
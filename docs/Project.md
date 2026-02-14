# INTRODUCTION

The project is a job search application based on technology tags. It aggregates job listings from multiple external APIs, caches them in-memory for performance, and provides a unified API for searching jobs by tags.

Users need to answer questions from a question's database, which will be used to determine their technology stack and recommend relevant job listings.

## Question Database

Admins can create and manage questions in the database, adding tags, weight, level and other metadata. The questions are used to assess the user's skills and preferences, which in turn helps in recommending jobs that match their profile.

## The ranking system

The ranking system uses the tags fro each question and their level to determine which level the user is in each tag. The system then uses this information to recommend jobs that match the user's skill level and preferences.

## Calculation

If a user has 70% of assertion for each level of tags, they will be considered to be at that level. For example, if a user has 70% of assertions for the "React" tag at level 2, they will be considered to be at level 2 for that tag. This allows the system to recommend jobs that match the user's skill level and preferences more accurately.

A user can only reach the next level if they have reached the previous level. For example, a user cannot reach level 3 for the "React" tag if they have not reached level 2 for that tag. This ensures that users are progressing through the levels in a logical manner and that they are being recommended jobs that match their skill level and preferences.

## User interface

User can select a lot of tags and answer questions related to those tags. The system will then use the answers to determine the user's skill level for each tag and recommend jobs that match their profile. The user interface is designed to be intuitive and user-friendly, allowing users to easily navigate through the questions and view their job recommendations.
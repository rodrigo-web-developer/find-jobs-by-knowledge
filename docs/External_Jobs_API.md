# Introduction

This document describes all the external APIs integrated into the job search application. The application aggregates job listings from multiple sources, providing users with a comprehensive set of job opportunities based on their technology tags.

## Torre.ai

Torre.ai is a popular job search platform that provides an API for accessing job listings. The application integrates with Torre.ai to fetch job listings based on technology tags.

How to use the Torre.ai API:

`POST https://search.torre.co/opportunities/_search?&params`
(searches for opportunities)

Query params:
- &currency=USD
— &periodicity=hourly
— &lang=en
— &size=10
— &contextFeature=job_feed

Request body: 
```json
{
  "and": [
    {
      "keywords": {
        "term": "Designer",
        "locale": "en"
      }
    },
    {
      "language": {
        "term": "English",
        "fluency": "fully-fluent"
      }
    },
    {
      "skill/role": {
        "text": "Design systems",
        "proficiency": "expert"
      }
    },
    {
      "skill/role": {
        "text": "Product design",
        "proficiency": "expert"
      }
    },
    {
      "status": {
        "code": "open"
      }
    }
  ]
}
```

Keywords in the request body can be replaced with the technology tags selected by the user. The API will return job listings that match the specified criteria.
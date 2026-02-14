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


Response Body:

```json
{
    "total": 11,
    "size": 3,
    "results": [
        {
            "id": "QwejvMMd",
            "objective": "Staff Product Designer, Platform/Design Systems",
            "slug": "floqast-staff-product-designer-platformdesign-systems",
            "tagline": "You'll architect AI-driven experiences & lead design system innovation.",
            "theme": "default",
            "type": "full-time-employment",
            "opportunity": "employee",
            "organizations": [
                {
                    "id": 745456,
                    "hashedId": "0Za46R4q",
                    "name": "FloQast",
                    "status": "approved",
                    "size": 839,
                    "publicId": "FloQast",
                    "picture": "https://res.cloudinary.com/torre-technologies-co/image/upload/v1769419214/origin/bio/crawled-organizations/floqast_logo_skfwft.jpg",
                    "theme": "default"
                }
            ],
            "locations": [
                "United States"
            ],
            "timezones": null,
            "remote": true,
            "external": true,
            "deadline": null,
            "created": "2025-11-16T02:19:18.000Z",
            "status": "open",
            "commitment": "full-time",
            "externalApplicationUrl": "https://jobs.lever.co/floqast/bcc57f28-6f6f-407f-9248-84b78ed15dbc",
            "compensation": {
                "data": {
                    "code": "range",
                    "currency": "USD",
                    "minAmount": 164000.0,
                    "minHourlyUSD": 85.41666666666667,
                    "maxAmount": 246000.0,
                    "maxHourlyUSD": 128.125,
                    "periodicity": "yearly",
                    "negotiable": false,
                    "conversionRateUSD": 1.0
                },
                "visible": true,
                "additionalCompensationDetails": {}
            },
            "skills": [
                {
                    "name": "CSS",
                    "experience": "potential-to-develop",
                    "proficiency": "proficient"
                },
                {
                    "name": "Figma",
                    "experience": "potential-to-develop",
                    "proficiency": "expert"
                },
                {
                    "name": "Git",
                    "experience": "potential-to-develop",
                    "proficiency": "proficient"
                },
                {
                    "name": "GitHub",
                    "experience": "potential-to-develop",
                    "proficiency": "proficient"
                },
                {
                    "name": "HTML",
                    "experience": "potential-to-develop",
                    "proficiency": "proficient"
                },
                {
                    "name": "Package manager",
                    "experience": "potential-to-develop",
                    "proficiency": "proficient"
                },
                {
                    "name": "React.js",
                    "experience": "potential-to-develop",
                    "proficiency": "proficient"
                },
                {
                    "name": "Storybook",
                    "experience": "potential-to-develop",
                    "proficiency": "proficient"
                },
                {
                    "name": "Version control",
                    "experience": "potential-to-develop",
                    "proficiency": "proficient"
                }
            ],
            "members": [],
            "place": {
                "remote": true,
                "anywhere": false,
                "timezone": false,
                "locationType": "remote_countries",
                "location": [
                    {
                        "id": "United States",
                        "timezone": -6.0,
                        "countryCode": null,
                        "latitude": 37.09024,
                        "longitude": -95.712891
                    }
                ]
            },
            "questions": [],
            "context": {
                "signaled": [],
                "applicationStatus": null
            },
            "additionalCompensation": [],
            "additionalCompensationDetails": {},
            "_meta": {
                "rank": {
                    "position": 1,
                    "value": 0.8000000000000002,
                    "boostedValue": 0.9766089965397925
                },
                "scorer": {
                    "@type": "and",
                    "score": 0.9882352941176471,
                    "min": 0.9882352941176471,
                    "max": 1.0,
                    "uncertain": true,
                    "rank": 5.0,
                    "and": [
                        {
                            "@type": "and",
                            "score": 1.0,
                            "min": 1.0,
                            "max": 1.0,
                            "uncertain": true,
                            "rank": 5.0,
                            "and": [
                                {
                                    "@type": "or",
                                    "score": 1.0,
                                    "min": 1.0,
                                    "max": 1.0,
                                    "uncertain": true,
                                    "rank": 1.0,
                                    "or": [
                                        {
                                            "@type": "concrete",
                                            "id": "proficiency",
                                            "input": {
                                                "criteria": {
                                                    "skills": [],
                                                    "proficiencies": {},
                                                    "experiences": [],
                                                    "queryContext": "search",
                                                    "skillsForMatching": null
                                                },
                                                "opportunity": {
                                                    "skills": [
                                                        {
                                                            "name": "Figma"
                                                        },
                                                        {
                                                            "name": "CSS"
                                                        },
                                                        {
                                                            "name": "Git"
                                                        },
                                                        {
                                                            "name": "GitHub"
                                                        },
                                                        {
                                                            "name": "HTML"
                                                        },
                                                        {
                                                            "name": "Package manager"
                                                        },
                                                        {
                                                            "name": "React.js"
                                                        },
                                                        {
                                                            "name": "Storybook"
                                                        },
                                                        {
                                                            "name": "Version control"
                                                        }
                                                    ],
                                                    "proficiencies": {
                                                        "Figma": "expert",
                                                        "CSS": "proficient",
                                                        "Git": "proficient",
                                                        "GitHub": "proficient",
                                                        "HTML": "proficient",
                                                        "Package manager": "proficient",
                                                        "React.js": "proficient",
                                                        "Storybook": "proficient",
                                                        "Version control": "proficient"
                                                    },
                                                    "experiences": {},
                                                    "skillMatchEvaluations": [
                                                        {
                                                            "opportunitySkill": "CSS",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "Figma",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "Git",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "GitHub",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "HTML",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "Package manager",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "React.js",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "Storybook",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "Version control",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        }
                                                    ],
                                                    "experienceEvaluations": []
                                                },
                                                "suggested-genome-changes": {
                                                    "missing": [
                                                        {
                                                            "code": 62652,
                                                            "name": "Figma",
                                                            "proficiency": "expert",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 23009,
                                                            "name": "CSS",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 235856,
                                                            "name": "Git",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 18374,
                                                            "name": "GitHub",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 23802,
                                                            "name": "HTML",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 7397175,
                                                            "name": "Package manager",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 23818,
                                                            "name": "React.js",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 490934,
                                                            "name": "Storybook",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 6086275,
                                                            "name": "Version control",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        }
                                                    ]
                                                }
                                            },
                                            "score": 0.0,
                                            "min": 0.0,
                                            "max": 0.0,
                                            "uncertain": true,
                                            "rank": 10.0,
                                            "missingInformation": false,
                                            "debug": null
                                        },
                                        {
                                            "@type": "concrete",
                                            "id": "role",
                                            "input": {
                                                "criteria": {
                                                    "role": "Design systems"
                                                },
                                                "opportunity": {
                                                    "role": "Staff Product Designer, Platform/Design Systems"
                                                },
                                                "suggested-genome-changes": null
                                            },
                                            "score": 1.0,
                                            "min": 1.0,
                                            "max": 1.0,
                                            "uncertain": false,
                                            "rank": 1.0,
                                            "missingInformation": false,
                                            "debug": null
                                        }
                                    ]
                                },
                                {
                                    "@type": "or",
                                    "score": 1.0,
                                    "min": 1.0,
                                    "max": 1.0,
                                    "uncertain": true,
                                    "rank": 1.0,
                                    "or": [
                                        {
                                            "@type": "concrete",
                                            "id": "proficiency",
                                            "input": {
                                                "criteria": {
                                                    "skills": [],
                                                    "proficiencies": {},
                                                    "experiences": [],
                                                    "queryContext": "search",
                                                    "skillsForMatching": null
                                                },
                                                "opportunity": {
                                                    "skills": [
                                                        {
                                                            "name": "Figma"
                                                        },
                                                        {
                                                            "name": "CSS"
                                                        },
                                                        {
                                                            "name": "Git"
                                                        },
                                                        {
                                                            "name": "GitHub"
                                                        },
                                                        {
                                                            "name": "HTML"
                                                        },
                                                        {
                                                            "name": "Package manager"
                                                        },
                                                        {
                                                            "name": "React.js"
                                                        },
                                                        {
                                                            "name": "Storybook"
                                                        },
                                                        {
                                                            "name": "Version control"
                                                        }
                                                    ],
                                                    "proficiencies": {
                                                        "Figma": "expert",
                                                        "CSS": "proficient",
                                                        "Git": "proficient",
                                                        "GitHub": "proficient",
                                                        "HTML": "proficient",
                                                        "Package manager": "proficient",
                                                        "React.js": "proficient",
                                                        "Storybook": "proficient",
                                                        "Version control": "proficient"
                                                    },
                                                    "experiences": {},
                                                    "skillMatchEvaluations": [
                                                        {
                                                            "opportunitySkill": "CSS",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "Figma",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "Git",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "GitHub",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "HTML",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "Package manager",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "React.js",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "Storybook",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "Version control",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        }
                                                    ],
                                                    "experienceEvaluations": []
                                                },
                                                "suggested-genome-changes": {
                                                    "missing": [
                                                        {
                                                            "code": 62652,
                                                            "name": "Figma",
                                                            "proficiency": "expert",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 23009,
                                                            "name": "CSS",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 235856,
                                                            "name": "Git",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 18374,
                                                            "name": "GitHub",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 23802,
                                                            "name": "HTML",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 7397175,
                                                            "name": "Package manager",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 23818,
                                                            "name": "React.js",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 490934,
                                                            "name": "Storybook",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 6086275,
                                                            "name": "Version control",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        }
                                                    ]
                                                }
                                            },
                                            "score": 0.0,
                                            "min": 0.0,
                                            "max": 0.0,
                                            "uncertain": true,
                                            "rank": 10.0,
                                            "missingInformation": false,
                                            "debug": null
                                        },
                                        {
                                            "@type": "concrete",
                                            "id": "role",
                                            "input": {
                                                "criteria": {
                                                    "role": "Product design"
                                                },
                                                "opportunity": {
                                                    "role": "Staff Product Designer, Platform/Design Systems"
                                                },
                                                "suggested-genome-changes": null
                                            },
                                            "score": 1.0,
                                            "min": 1.0,
                                            "max": 1.0,
                                            "uncertain": false,
                                            "rank": 1.0,
                                            "missingInformation": false,
                                            "debug": null
                                        }
                                    ]
                                },
                                {
                                    "@type": "concrete",
                                    "id": "keywords",
                                    "input": {
                                        "criteria": {
                                            "keywords": [
                                                "designer"
                                            ]
                                        },
                                        "opportunity": {},
                                        "suggested-genome-changes": null
                                    },
                                    "score": 1.0,
                                    "min": 1.0,
                                    "max": 1.0,
                                    "uncertain": false,
                                    "rank": 9.0,
                                    "missingInformation": false,
                                    "debug": null
                                }
                            ]
                        },
                        {
                            "@type": "concrete",
                            "id": "completion",
                            "input": {
                                "criteria": null,
                                "opportunity": {
                                    "completion": 0.4
                                },
                                "suggested-genome-changes": null
                            },
                            "score": 0.4,
                            "min": 0.4,
                            "max": 1.0,
                            "uncertain": false,
                            "rank": 1.0,
                            "missingInformation": false,
                            "debug": null
                        }
                    ]
                },
                "filter": {
                    "@type": "and",
                    "pass": true,
                    "and": [
                        {
                            "@type": "concrete",
                            "pass": true,
                            "id": "language",
                            "input": {
                                "criteria": {
                                    "languages": {
                                        "en": "fully-fluent"
                                    }
                                },
                                "opportunity": {
                                    "languages": {
                                        "en": "conversational"
                                    }
                                },
                                "suggested-genome-changes": {
                                    "missing-language": null
                                }
                            },
                            "debug": null
                        },
                        {
                            "@type": "or",
                            "pass": true,
                            "or": [
                                {
                                    "@type": "concrete",
                                    "pass": false,
                                    "id": "proficiency",
                                    "input": {
                                        "criteria": {
                                            "skills": [],
                                            "proficiencies": {},
                                            "experiences": [],
                                            "queryContext": "search",
                                            "skillsForMatching": null
                                        },
                                        "opportunity": {
                                            "skills": [
                                                {
                                                    "name": "Figma"
                                                },
                                                {
                                                    "name": "CSS"
                                                },
                                                {
                                                    "name": "Git"
                                                },
                                                {
                                                    "name": "GitHub"
                                                },
                                                {
                                                    "name": "HTML"
                                                },
                                                {
                                                    "name": "Package manager"
                                                },
                                                {
                                                    "name": "React.js"
                                                },
                                                {
                                                    "name": "Storybook"
                                                },
                                                {
                                                    "name": "Version control"
                                                }
                                            ],
                                            "proficiencies": {
                                                "Figma": "expert",
                                                "CSS": "proficient",
                                                "Git": "proficient",
                                                "GitHub": "proficient",
                                                "HTML": "proficient",
                                                "Package manager": "proficient",
                                                "React.js": "proficient",
                                                "Storybook": "proficient",
                                                "Version control": "proficient"
                                            },
                                            "experiences": {},
                                            "skillMatchEvaluations": [
                                                {
                                                    "opportunitySkill": "CSS",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "Figma",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "Git",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "GitHub",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "HTML",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "Package manager",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "React.js",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "Storybook",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "Version control",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                }
                                            ],
                                            "experienceEvaluations": []
                                        },
                                        "suggested-genome-changes": {
                                            "missing": [
                                                {
                                                    "code": 62652,
                                                    "name": "Figma",
                                                    "proficiency": "expert",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 23009,
                                                    "name": "CSS",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 235856,
                                                    "name": "Git",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 18374,
                                                    "name": "GitHub",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 23802,
                                                    "name": "HTML",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 7397175,
                                                    "name": "Package manager",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 23818,
                                                    "name": "React.js",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 490934,
                                                    "name": "Storybook",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 6086275,
                                                    "name": "Version control",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                }
                                            ]
                                        }
                                    },
                                    "debug": null
                                },
                                {
                                    "@type": "concrete",
                                    "pass": true,
                                    "id": "role",
                                    "input": {
                                        "criteria": {
                                            "role": "Design systems"
                                        },
                                        "opportunity": {
                                            "role": "Staff Product Designer, Platform/Design Systems"
                                        },
                                        "suggested-genome-changes": null
                                    },
                                    "debug": null
                                }
                            ]
                        },
                        {
                            "@type": "or",
                            "pass": true,
                            "or": [
                                {
                                    "@type": "concrete",
                                    "pass": false,
                                    "id": "proficiency",
                                    "input": {
                                        "criteria": {
                                            "skills": [],
                                            "proficiencies": {},
                                            "experiences": [],
                                            "queryContext": "search",
                                            "skillsForMatching": null
                                        },
                                        "opportunity": {
                                            "skills": [
                                                {
                                                    "name": "Figma"
                                                },
                                                {
                                                    "name": "CSS"
                                                },
                                                {
                                                    "name": "Git"
                                                },
                                                {
                                                    "name": "GitHub"
                                                },
                                                {
                                                    "name": "HTML"
                                                },
                                                {
                                                    "name": "Package manager"
                                                },
                                                {
                                                    "name": "React.js"
                                                },
                                                {
                                                    "name": "Storybook"
                                                },
                                                {
                                                    "name": "Version control"
                                                }
                                            ],
                                            "proficiencies": {
                                                "Figma": "expert",
                                                "CSS": "proficient",
                                                "Git": "proficient",
                                                "GitHub": "proficient",
                                                "HTML": "proficient",
                                                "Package manager": "proficient",
                                                "React.js": "proficient",
                                                "Storybook": "proficient",
                                                "Version control": "proficient"
                                            },
                                            "experiences": {},
                                            "skillMatchEvaluations": [
                                                {
                                                    "opportunitySkill": "CSS",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "Figma",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "Git",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "GitHub",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "HTML",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "Package manager",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "React.js",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "Storybook",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "Version control",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                }
                                            ],
                                            "experienceEvaluations": []
                                        },
                                        "suggested-genome-changes": {
                                            "missing": [
                                                {
                                                    "code": 62652,
                                                    "name": "Figma",
                                                    "proficiency": "expert",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 23009,
                                                    "name": "CSS",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 235856,
                                                    "name": "Git",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 18374,
                                                    "name": "GitHub",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 23802,
                                                    "name": "HTML",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 7397175,
                                                    "name": "Package manager",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 23818,
                                                    "name": "React.js",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 490934,
                                                    "name": "Storybook",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 6086275,
                                                    "name": "Version control",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                }
                                            ]
                                        }
                                    },
                                    "debug": null
                                },
                                {
                                    "@type": "concrete",
                                    "pass": true,
                                    "id": "role",
                                    "input": {
                                        "criteria": {
                                            "role": "Product design"
                                        },
                                        "opportunity": {
                                            "role": "Staff Product Designer, Platform/Design Systems"
                                        },
                                        "suggested-genome-changes": null
                                    },
                                    "debug": null
                                }
                            ]
                        },
                        {
                            "@type": "concrete",
                            "pass": true,
                            "id": "keywords",
                            "input": {
                                "criteria": {
                                    "keywords": [
                                        "designer"
                                    ]
                                },
                                "opportunity": {},
                                "suggested-genome-changes": null
                            },
                            "debug": null
                        },
                        {
                            "@type": "concrete",
                            "pass": true,
                            "id": "status",
                            "input": {
                                "criteria": {
                                    "status": "open"
                                },
                                "opportunity": {
                                    "status": "open"
                                },
                                "suggested-genome-changes": null
                            },
                            "debug": null
                        }
                    ]
                },
                "boosters": [
                    "native",
                    "reach"
                ]
            },
            "videoUrl": null,
            "serviceTypes": [
                "essential"
            ],
            "quickApply": true
        },
        {
            "id": "Yd6LNa1W",
            "objective": "Senior Product Designer - Design Systems",
            "slug": "moonpig-senior-product-designer-design-systems",
            "tagline": "You'll shape the future of design systems, driving innovation and elevating user experiences across global brands.",
            "theme": "default",
            "type": "full-time-employment",
            "opportunity": "employee",
            "organizations": [
                {
                    "id": 387997,
                    "hashedId": "zq7lAaxZ",
                    "name": "Moonpig",
                    "status": "approved",
                    "size": null,
                    "publicId": "Moonpig",
                    "picture": "https://res.cloudinary.com/torre-technologies-co/image/upload/v1764639013/origin/bio/crawled-organizations/moonpig_com_logo_x0g144.jpg",
                    "theme": "default"
                }
            ],
            "locations": [
                "London, UK"
            ],
            "timezones": null,
            "remote": false,
            "external": true,
            "deadline": null,
            "created": "2025-12-09T21:13:38.000Z",
            "status": "open",
            "commitment": "full-time",
            "externalApplicationUrl": "https://jobs.lever.co/moonpig/fc366ab9-a60a-492a-a01f-3b0d174be4d4",
            "compensation": {
                "data": {
                    "code": "to-be-agreed",
                    "currency": "USD",
                    "minAmount": 0.0,
                    "minHourlyUSD": 0.0,
                    "maxAmount": 0.0,
                    "maxHourlyUSD": 0.0,
                    "periodicity": "monthly",
                    "negotiable": false,
                    "conversionRateUSD": 1.0
                },
                "visible": true,
                "additionalCompensationDetails": {}
            },
            "skills": [
                {
                    "name": "Design engineering",
                    "experience": "potential-to-develop",
                    "proficiency": "proficient"
                },
                {
                    "name": "Design systems",
                    "experience": "potential-to-develop",
                    "proficiency": "proficient"
                },
                {
                    "name": "Figma",
                    "experience": "potential-to-develop",
                    "proficiency": "proficient"
                },
                {
                    "name": "React.js",
                    "experience": "potential-to-develop",
                    "proficiency": "proficient"
                },
                {
                    "name": "Storybook",
                    "experience": "potential-to-develop",
                    "proficiency": "proficient"
                },
                {
                    "name": "TypeScript",
                    "experience": "potential-to-develop",
                    "proficiency": "proficient"
                }
            ],
            "members": [],
            "place": {
                "remote": false,
                "anywhere": false,
                "timezone": false,
                "locationType": "hybrid",
                "location": [
                    {
                        "id": "London, UK",
                        "timezone": null,
                        "countryCode": "GB",
                        "latitude": 51.5072178,
                        "longitude": -0.1275862
                    }
                ]
            },
            "questions": [],
            "context": {
                "signaled": [],
                "applicationStatus": null
            },
            "additionalCompensation": [],
            "additionalCompensationDetails": {},
            "_meta": {
                "rank": {
                    "position": 2,
                    "value": 0.6,
                    "boostedValue": 0.9727374086889659
                },
                "scorer": {
                    "@type": "and",
                    "score": 0.9862745098039216,
                    "min": 0.9862745098039216,
                    "max": 1.0,
                    "uncertain": true,
                    "rank": 2.0,
                    "and": [
                        {
                            "@type": "and",
                            "score": 1.0,
                            "min": 1.0,
                            "max": 1.0,
                            "uncertain": true,
                            "rank": 1.0,
                            "and": [
                                {
                                    "@type": "or",
                                    "score": 1.0,
                                    "min": 1.0,
                                    "max": 1.0,
                                    "uncertain": true,
                                    "rank": 1.0,
                                    "or": [
                                        {
                                            "@type": "concrete",
                                            "id": "proficiency",
                                            "input": {
                                                "criteria": {
                                                    "skills": [
                                                        {
                                                            "name": "Design systems",
                                                            "skillRef": null
                                                        }
                                                    ],
                                                    "proficiencies": {
                                                        "Design systems": "expert"
                                                    },
                                                    "experiences": [],
                                                    "queryContext": "search",
                                                    "skillsForMatching": null
                                                },
                                                "opportunity": {
                                                    "skills": [
                                                        {
                                                            "name": "Design engineering"
                                                        },
                                                        {
                                                            "name": "Design systems"
                                                        },
                                                        {
                                                            "name": "Figma"
                                                        },
                                                        {
                                                            "name": "React.js"
                                                        },
                                                        {
                                                            "name": "Storybook"
                                                        },
                                                        {
                                                            "name": "TypeScript"
                                                        }
                                                    ],
                                                    "proficiencies": {
                                                        "Design engineering": "proficient",
                                                        "Design systems": "proficient",
                                                        "Figma": "proficient",
                                                        "React.js": "proficient",
                                                        "Storybook": "proficient",
                                                        "TypeScript": "proficient"
                                                    },
                                                    "experiences": {},
                                                    "skillMatchEvaluations": [
                                                        {
                                                            "opportunitySkill": "Design systems",
                                                            "skillMatchType": "exact-match",
                                                            "maxProficiency": "expert",
                                                            "maxRelevantProficiency": "expert",
                                                            "implicitMatch": false,
                                                            "matchingSkills": [
                                                                {
                                                                    "skillName": "Design systems",
                                                                    "proficiency": "expert",
                                                                    "relevantProficiency": "expert",
                                                                    "implicitMatch": false
                                                                }
                                                            ]
                                                        },
                                                        {
                                                            "opportunitySkill": "Design engineering",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "Figma",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "React.js",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "Storybook",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "TypeScript",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        }
                                                    ],
                                                    "experienceEvaluations": []
                                                },
                                                "suggested-genome-changes": {
                                                    "missing": [
                                                        {
                                                            "code": -2147479300,
                                                            "name": "Design engineering",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 62652,
                                                            "name": "Figma",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 23818,
                                                            "name": "React.js",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 490934,
                                                            "name": "Storybook",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 32590,
                                                            "name": "TypeScript",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        }
                                                    ]
                                                }
                                            },
                                            "score": 0.16666666666666666,
                                            "min": 0.16666666666666666,
                                            "max": 0.16666666666666666,
                                            "uncertain": true,
                                            "rank": 9.0,
                                            "missingInformation": false,
                                            "debug": null
                                        },
                                        {
                                            "@type": "concrete",
                                            "id": "role",
                                            "input": {
                                                "criteria": {
                                                    "role": "Design systems"
                                                },
                                                "opportunity": {
                                                    "role": "Senior Product Designer - Design Systems"
                                                },
                                                "suggested-genome-changes": null
                                            },
                                            "score": 1.0,
                                            "min": 1.0,
                                            "max": 1.0,
                                            "uncertain": false,
                                            "rank": 1.0,
                                            "missingInformation": false,
                                            "debug": null
                                        }
                                    ]
                                },
                                {
                                    "@type": "or",
                                    "score": 1.0,
                                    "min": 1.0,
                                    "max": 1.0,
                                    "uncertain": true,
                                    "rank": 1.0,
                                    "or": [
                                        {
                                            "@type": "concrete",
                                            "id": "proficiency",
                                            "input": {
                                                "criteria": {
                                                    "skills": [],
                                                    "proficiencies": {},
                                                    "experiences": [],
                                                    "queryContext": "search",
                                                    "skillsForMatching": null
                                                },
                                                "opportunity": {
                                                    "skills": [
                                                        {
                                                            "name": "Design engineering"
                                                        },
                                                        {
                                                            "name": "Design systems"
                                                        },
                                                        {
                                                            "name": "Figma"
                                                        },
                                                        {
                                                            "name": "React.js"
                                                        },
                                                        {
                                                            "name": "Storybook"
                                                        },
                                                        {
                                                            "name": "TypeScript"
                                                        }
                                                    ],
                                                    "proficiencies": {
                                                        "Design engineering": "proficient",
                                                        "Design systems": "proficient",
                                                        "Figma": "proficient",
                                                        "React.js": "proficient",
                                                        "Storybook": "proficient",
                                                        "TypeScript": "proficient"
                                                    },
                                                    "experiences": {},
                                                    "skillMatchEvaluations": [
                                                        {
                                                            "opportunitySkill": "Design systems",
                                                            "skillMatchType": "exact-match",
                                                            "maxProficiency": "expert",
                                                            "maxRelevantProficiency": "expert",
                                                            "implicitMatch": false,
                                                            "matchingSkills": [
                                                                {
                                                                    "skillName": "Design systems",
                                                                    "proficiency": "expert",
                                                                    "relevantProficiency": "expert",
                                                                    "implicitMatch": false
                                                                }
                                                            ]
                                                        },
                                                        {
                                                            "opportunitySkill": "Design engineering",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "Figma",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "React.js",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "Storybook",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "TypeScript",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        }
                                                    ],
                                                    "experienceEvaluations": []
                                                },
                                                "suggested-genome-changes": {
                                                    "missing": [
                                                        {
                                                            "code": -2147479300,
                                                            "name": "Design engineering",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 62652,
                                                            "name": "Figma",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 23818,
                                                            "name": "React.js",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 490934,
                                                            "name": "Storybook",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 32590,
                                                            "name": "TypeScript",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        }
                                                    ]
                                                }
                                            },
                                            "score": 0.16666666666666666,
                                            "min": 0.16666666666666666,
                                            "max": 0.16666666666666666,
                                            "uncertain": true,
                                            "rank": 9.0,
                                            "missingInformation": false,
                                            "debug": null
                                        },
                                        {
                                            "@type": "concrete",
                                            "id": "role",
                                            "input": {
                                                "criteria": {
                                                    "role": "Product design"
                                                },
                                                "opportunity": {
                                                    "role": "Senior Product Designer - Design Systems"
                                                },
                                                "suggested-genome-changes": null
                                            },
                                            "score": 1.0,
                                            "min": 1.0,
                                            "max": 1.0,
                                            "uncertain": false,
                                            "rank": 1.0,
                                            "missingInformation": false,
                                            "debug": null
                                        }
                                    ]
                                },
                                {
                                    "@type": "concrete",
                                    "id": "keywords",
                                    "input": {
                                        "criteria": {
                                            "keywords": [
                                                "designer"
                                            ]
                                        },
                                        "opportunity": {},
                                        "suggested-genome-changes": null
                                    },
                                    "score": 1.0,
                                    "min": 1.0,
                                    "max": 1.0,
                                    "uncertain": false,
                                    "rank": 1.0,
                                    "missingInformation": false,
                                    "debug": null
                                }
                            ]
                        },
                        {
                            "@type": "concrete",
                            "id": "completion",
                            "input": {
                                "criteria": null,
                                "opportunity": {
                                    "completion": 0.3
                                },
                                "suggested-genome-changes": null
                            },
                            "score": 0.3,
                            "min": 0.3,
                            "max": 1.0,
                            "uncertain": false,
                            "rank": 5.0,
                            "missingInformation": false,
                            "debug": null
                        }
                    ]
                },
                "filter": {
                    "@type": "and",
                    "pass": true,
                    "and": [
                        {
                            "@type": "or",
                            "pass": true,
                            "or": [
                                {
                                    "@type": "concrete",
                                    "pass": false,
                                    "id": "proficiency",
                                    "input": {
                                        "criteria": {
                                            "skills": [
                                                {
                                                    "name": "Design systems",
                                                    "skillRef": null
                                                }
                                            ],
                                            "proficiencies": {
                                                "Design systems": "expert"
                                            },
                                            "experiences": [],
                                            "queryContext": "search",
                                            "skillsForMatching": null
                                        },
                                        "opportunity": {
                                            "skills": [
                                                {
                                                    "name": "Design engineering"
                                                },
                                                {
                                                    "name": "Design systems"
                                                },
                                                {
                                                    "name": "Figma"
                                                },
                                                {
                                                    "name": "React.js"
                                                },
                                                {
                                                    "name": "Storybook"
                                                },
                                                {
                                                    "name": "TypeScript"
                                                }
                                            ],
                                            "proficiencies": {
                                                "Design engineering": "proficient",
                                                "Design systems": "proficient",
                                                "Figma": "proficient",
                                                "React.js": "proficient",
                                                "Storybook": "proficient",
                                                "TypeScript": "proficient"
                                            },
                                            "experiences": {},
                                            "skillMatchEvaluations": [
                                                {
                                                    "opportunitySkill": "Design systems",
                                                    "skillMatchType": "exact-match",
                                                    "maxProficiency": "expert",
                                                    "maxRelevantProficiency": "expert",
                                                    "implicitMatch": false,
                                                    "matchingSkills": [
                                                        {
                                                            "skillName": "Design systems",
                                                            "proficiency": "expert",
                                                            "relevantProficiency": "expert",
                                                            "implicitMatch": false
                                                        }
                                                    ]
                                                },
                                                {
                                                    "opportunitySkill": "Design engineering",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "Figma",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "React.js",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "Storybook",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "TypeScript",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                }
                                            ],
                                            "experienceEvaluations": []
                                        },
                                        "suggested-genome-changes": {
                                            "missing": [
                                                {
                                                    "code": -2147479300,
                                                    "name": "Design engineering",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 62652,
                                                    "name": "Figma",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 23818,
                                                    "name": "React.js",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 490934,
                                                    "name": "Storybook",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 32590,
                                                    "name": "TypeScript",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                }
                                            ]
                                        }
                                    },
                                    "debug": null
                                },
                                {
                                    "@type": "concrete",
                                    "pass": true,
                                    "id": "role",
                                    "input": {
                                        "criteria": {
                                            "role": "Design systems"
                                        },
                                        "opportunity": {
                                            "role": "Senior Product Designer - Design Systems"
                                        },
                                        "suggested-genome-changes": null
                                    },
                                    "debug": null
                                }
                            ]
                        },
                        {
                            "@type": "concrete",
                            "pass": true,
                            "id": "language",
                            "input": {
                                "criteria": {
                                    "languages": {
                                        "en": "fully-fluent"
                                    }
                                },
                                "opportunity": {
                                    "languages": {
                                        "en": "conversational"
                                    }
                                },
                                "suggested-genome-changes": {
                                    "missing-language": null
                                }
                            },
                            "debug": null
                        },
                        {
                            "@type": "or",
                            "pass": true,
                            "or": [
                                {
                                    "@type": "concrete",
                                    "pass": false,
                                    "id": "proficiency",
                                    "input": {
                                        "criteria": {
                                            "skills": [],
                                            "proficiencies": {},
                                            "experiences": [],
                                            "queryContext": "search",
                                            "skillsForMatching": null
                                        },
                                        "opportunity": {
                                            "skills": [
                                                {
                                                    "name": "Design engineering"
                                                },
                                                {
                                                    "name": "Design systems"
                                                },
                                                {
                                                    "name": "Figma"
                                                },
                                                {
                                                    "name": "React.js"
                                                },
                                                {
                                                    "name": "Storybook"
                                                },
                                                {
                                                    "name": "TypeScript"
                                                }
                                            ],
                                            "proficiencies": {
                                                "Design engineering": "proficient",
                                                "Design systems": "proficient",
                                                "Figma": "proficient",
                                                "React.js": "proficient",
                                                "Storybook": "proficient",
                                                "TypeScript": "proficient"
                                            },
                                            "experiences": {},
                                            "skillMatchEvaluations": [
                                                {
                                                    "opportunitySkill": "Design systems",
                                                    "skillMatchType": "exact-match",
                                                    "maxProficiency": "expert",
                                                    "maxRelevantProficiency": "expert",
                                                    "implicitMatch": false,
                                                    "matchingSkills": [
                                                        {
                                                            "skillName": "Design systems",
                                                            "proficiency": "expert",
                                                            "relevantProficiency": "expert",
                                                            "implicitMatch": false
                                                        }
                                                    ]
                                                },
                                                {
                                                    "opportunitySkill": "Design engineering",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "Figma",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "React.js",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "Storybook",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "TypeScript",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                }
                                            ],
                                            "experienceEvaluations": []
                                        },
                                        "suggested-genome-changes": {
                                            "missing": [
                                                {
                                                    "code": -2147479300,
                                                    "name": "Design engineering",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 62652,
                                                    "name": "Figma",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 23818,
                                                    "name": "React.js",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 490934,
                                                    "name": "Storybook",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 32590,
                                                    "name": "TypeScript",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                }
                                            ]
                                        }
                                    },
                                    "debug": null
                                },
                                {
                                    "@type": "concrete",
                                    "pass": true,
                                    "id": "role",
                                    "input": {
                                        "criteria": {
                                            "role": "Product design"
                                        },
                                        "opportunity": {
                                            "role": "Senior Product Designer - Design Systems"
                                        },
                                        "suggested-genome-changes": null
                                    },
                                    "debug": null
                                }
                            ]
                        },
                        {
                            "@type": "concrete",
                            "pass": true,
                            "id": "status",
                            "input": {
                                "criteria": {
                                    "status": "open"
                                },
                                "opportunity": {
                                    "status": "open"
                                },
                                "suggested-genome-changes": null
                            },
                            "debug": null
                        },
                        {
                            "@type": "concrete",
                            "pass": true,
                            "id": "keywords",
                            "input": {
                                "criteria": {
                                    "keywords": [
                                        "designer"
                                    ]
                                },
                                "opportunity": {},
                                "suggested-genome-changes": null
                            },
                            "debug": null
                        }
                    ]
                },
                "boosters": [
                    "native",
                    "reach"
                ]
            },
            "videoUrl": null,
            "serviceTypes": [
                "essential"
            ],
            "quickApply": true
        },
        {
            "id": "Rrnm5Qyd",
            "objective": "Lead Product Designer-Design Systems",
            "slug": "upstox-lead-product-designer-design-systems-1",
            "tagline": "You'll shape the future of investing for millions.",
            "theme": "default",
            "type": "full-time-employment",
            "opportunity": "employee",
            "organizations": [
                {
                    "id": 788658,
                    "hashedId": "AqV0P3Lo",
                    "name": "Upstox",
                    "status": "approved",
                    "size": 2,
                    "publicId": "Upstox",
                    "picture": "https://res.cloudinary.com/torre-technologies-co/image/upload/v1760712308/origin/bio/crawled-organizations/upstox_logo_crcmlt.jpg",
                    "theme": "default"
                }
            ],
            "locations": [
                "Mumbai, Maharashtra, India"
            ],
            "timezones": null,
            "remote": false,
            "external": true,
            "deadline": null,
            "created": "2025-11-10T20:45:52.000Z",
            "status": "open",
            "commitment": "full-time",
            "externalApplicationUrl": "https://jobs.lever.co/upstox/99ccb572-a92e-4915-a5a6-d504ae4bde8b",
            "compensation": {
                "data": {
                    "code": "to-be-agreed",
                    "currency": "USD",
                    "minAmount": 0.0,
                    "minHourlyUSD": 0.0,
                    "maxAmount": 0.0,
                    "maxHourlyUSD": 0.0,
                    "periodicity": "monthly",
                    "negotiable": false,
                    "conversionRateUSD": 1.0
                },
                "visible": true,
                "additionalCompensationDetails": {}
            },
            "skills": [
                {
                    "name": "Accessibility",
                    "experience": "potential-to-develop",
                    "proficiency": "proficient"
                },
                {
                    "name": "Adobe XD",
                    "experience": "potential-to-develop",
                    "proficiency": "expert"
                },
                {
                    "name": "Figma",
                    "experience": "potential-to-develop",
                    "proficiency": "expert"
                },
                {
                    "name": "Fintech",
                    "experience": "potential-to-develop",
                    "proficiency": "proficient"
                },
                {
                    "name": "Product design",
                    "experience": "potential-to-develop",
                    "proficiency": "expert"
                },
                {
                    "name": "Sketch",
                    "experience": "potential-to-develop",
                    "proficiency": "expert"
                },
                {
                    "name": "User-centered design",
                    "experience": "potential-to-develop",
                    "proficiency": "proficient"
                }
            ],
            "members": [],
            "place": {
                "remote": false,
                "anywhere": false,
                "timezone": false,
                "locationType": "physical_location",
                "location": [
                    {
                        "id": "Mumbai, Maharashtra, India",
                        "timezone": 6.0,
                        "countryCode": null,
                        "latitude": 18.9581934,
                        "longitude": 72.8320729
                    }
                ]
            },
            "questions": [],
            "context": {
                "signaled": [],
                "applicationStatus": null
            },
            "additionalCompensation": [],
            "additionalCompensationDetails": {},
            "_meta": {
                "rank": {
                    "position": 3,
                    "value": 0.6,
                    "boostedValue": 0.9727374086889659
                },
                "scorer": {
                    "@type": "and",
                    "score": 0.9862745098039216,
                    "min": 0.9862745098039216,
                    "max": 1.0,
                    "uncertain": true,
                    "rank": 9.0,
                    "and": [
                        {
                            "@type": "and",
                            "score": 1.0,
                            "min": 1.0,
                            "max": 1.0,
                            "uncertain": true,
                            "rank": 7.0,
                            "and": [
                                {
                                    "@type": "or",
                                    "score": 1.0,
                                    "min": 1.0,
                                    "max": 1.0,
                                    "uncertain": true,
                                    "rank": 8.0,
                                    "or": [
                                        {
                                            "@type": "concrete",
                                            "id": "proficiency",
                                            "input": {
                                                "criteria": {
                                                    "skills": [
                                                        {
                                                            "name": "Design systems",
                                                            "skillRef": null
                                                        }
                                                    ],
                                                    "proficiencies": {
                                                        "Design systems": "expert"
                                                    },
                                                    "experiences": [],
                                                    "queryContext": "search",
                                                    "skillsForMatching": null
                                                },
                                                "opportunity": {
                                                    "skills": [
                                                        {
                                                            "name": "Adobe XD"
                                                        },
                                                        {
                                                            "name": "Figma"
                                                        },
                                                        {
                                                            "name": "Product design"
                                                        },
                                                        {
                                                            "name": "Sketch"
                                                        },
                                                        {
                                                            "name": "Accessibility"
                                                        },
                                                        {
                                                            "name": "Fintech"
                                                        },
                                                        {
                                                            "name": "User-centered design"
                                                        }
                                                    ],
                                                    "proficiencies": {
                                                        "Adobe XD": "expert",
                                                        "Figma": "expert",
                                                        "Product design": "expert",
                                                        "Sketch": "expert",
                                                        "Accessibility": "proficient",
                                                        "Fintech": "proficient",
                                                        "User-centered design": "proficient"
                                                    },
                                                    "experiences": {},
                                                    "skillMatchEvaluations": [
                                                        {
                                                            "opportunitySkill": "Product design",
                                                            "skillMatchType": "exact-match",
                                                            "maxProficiency": "expert",
                                                            "maxRelevantProficiency": "expert",
                                                            "implicitMatch": false,
                                                            "matchingSkills": [
                                                                {
                                                                    "skillName": "Product design",
                                                                    "proficiency": "expert",
                                                                    "relevantProficiency": "expert",
                                                                    "implicitMatch": false
                                                                }
                                                            ]
                                                        },
                                                        {
                                                            "opportunitySkill": "Accessibility",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "Adobe XD",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "Figma",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "Fintech",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "Sketch",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "User-centered design",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        }
                                                    ],
                                                    "experienceEvaluations": []
                                                },
                                                "suggested-genome-changes": {
                                                    "missing": [
                                                        {
                                                            "code": 15431355,
                                                            "name": "Adobe XD",
                                                            "proficiency": "expert",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 62652,
                                                            "name": "Figma",
                                                            "proficiency": "expert",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 51976,
                                                            "name": "Sketch",
                                                            "proficiency": "expert",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": -2147483427,
                                                            "name": "Accessibility",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 682491,
                                                            "name": "Fintech",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 59906,
                                                            "name": "User-centered design",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        }
                                                    ]
                                                }
                                            },
                                            "score": 0.1702127659574468,
                                            "min": 0.1702127659574468,
                                            "max": 0.1702127659574468,
                                            "uncertain": true,
                                            "rank": 3.0,
                                            "missingInformation": false,
                                            "debug": null
                                        },
                                        {
                                            "@type": "concrete",
                                            "id": "role",
                                            "input": {
                                                "criteria": {
                                                    "role": "Design systems"
                                                },
                                                "opportunity": {
                                                    "role": "Lead Product Designer-Design Systems"
                                                },
                                                "suggested-genome-changes": null
                                            },
                                            "score": 1.0,
                                            "min": 1.0,
                                            "max": 1.0,
                                            "uncertain": false,
                                            "rank": 6.0,
                                            "missingInformation": false,
                                            "debug": null
                                        }
                                    ]
                                },
                                {
                                    "@type": "or",
                                    "score": 1.0,
                                    "min": 1.0,
                                    "max": 1.0,
                                    "uncertain": true,
                                    "rank": 1.0,
                                    "or": [
                                        {
                                            "@type": "concrete",
                                            "id": "proficiency",
                                            "input": {
                                                "criteria": {
                                                    "skills": [
                                                        {
                                                            "name": "Product design",
                                                            "skillRef": null
                                                        }
                                                    ],
                                                    "proficiencies": {
                                                        "Product design": "expert"
                                                    },
                                                    "experiences": [],
                                                    "queryContext": "search",
                                                    "skillsForMatching": null
                                                },
                                                "opportunity": {
                                                    "skills": [
                                                        {
                                                            "name": "Adobe XD"
                                                        },
                                                        {
                                                            "name": "Figma"
                                                        },
                                                        {
                                                            "name": "Product design"
                                                        },
                                                        {
                                                            "name": "Sketch"
                                                        },
                                                        {
                                                            "name": "Accessibility"
                                                        },
                                                        {
                                                            "name": "Fintech"
                                                        },
                                                        {
                                                            "name": "User-centered design"
                                                        }
                                                    ],
                                                    "proficiencies": {
                                                        "Adobe XD": "expert",
                                                        "Figma": "expert",
                                                        "Product design": "expert",
                                                        "Sketch": "expert",
                                                        "Accessibility": "proficient",
                                                        "Fintech": "proficient",
                                                        "User-centered design": "proficient"
                                                    },
                                                    "experiences": {},
                                                    "skillMatchEvaluations": [
                                                        {
                                                            "opportunitySkill": "Product design",
                                                            "skillMatchType": "exact-match",
                                                            "maxProficiency": "expert",
                                                            "maxRelevantProficiency": "expert",
                                                            "implicitMatch": false,
                                                            "matchingSkills": [
                                                                {
                                                                    "skillName": "Product design",
                                                                    "proficiency": "expert",
                                                                    "relevantProficiency": "expert",
                                                                    "implicitMatch": false
                                                                }
                                                            ]
                                                        },
                                                        {
                                                            "opportunitySkill": "Accessibility",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "Adobe XD",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "Figma",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "Fintech",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "Sketch",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        },
                                                        {
                                                            "opportunitySkill": "User-centered design",
                                                            "skillMatchType": "missing-skill",
                                                            "maxProficiency": "no-experience-interested",
                                                            "maxRelevantProficiency": "no-experience-interested",
                                                            "implicitMatch": false,
                                                            "matchingSkills": []
                                                        }
                                                    ],
                                                    "experienceEvaluations": []
                                                },
                                                "suggested-genome-changes": {
                                                    "missing": [
                                                        {
                                                            "code": 15431355,
                                                            "name": "Adobe XD",
                                                            "proficiency": "expert",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 62652,
                                                            "name": "Figma",
                                                            "proficiency": "expert",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 51976,
                                                            "name": "Sketch",
                                                            "proficiency": "expert",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": -2147483427,
                                                            "name": "Accessibility",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 682491,
                                                            "name": "Fintech",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        },
                                                        {
                                                            "code": 59906,
                                                            "name": "User-centered design",
                                                            "proficiency": "proficient",
                                                            "implicitlyMatched": false
                                                        }
                                                    ]
                                                }
                                            },
                                            "score": 0.1702127659574468,
                                            "min": 0.1702127659574468,
                                            "max": 0.1702127659574468,
                                            "uncertain": true,
                                            "rank": 3.0,
                                            "missingInformation": false,
                                            "debug": null
                                        },
                                        {
                                            "@type": "concrete",
                                            "id": "role",
                                            "input": {
                                                "criteria": {
                                                    "role": "Product design"
                                                },
                                                "opportunity": {
                                                    "role": "Lead Product Designer-Design Systems"
                                                },
                                                "suggested-genome-changes": null
                                            },
                                            "score": 1.0,
                                            "min": 1.0,
                                            "max": 1.0,
                                            "uncertain": false,
                                            "rank": 1.0,
                                            "missingInformation": false,
                                            "debug": null
                                        }
                                    ]
                                },
                                {
                                    "@type": "concrete",
                                    "id": "keywords",
                                    "input": {
                                        "criteria": {
                                            "keywords": [
                                                "designer"
                                            ]
                                        },
                                        "opportunity": {},
                                        "suggested-genome-changes": null
                                    },
                                    "score": 1.0,
                                    "min": 1.0,
                                    "max": 1.0,
                                    "uncertain": false,
                                    "rank": 1.0,
                                    "missingInformation": false,
                                    "debug": null
                                }
                            ]
                        },
                        {
                            "@type": "concrete",
                            "id": "completion",
                            "input": {
                                "criteria": null,
                                "opportunity": {
                                    "completion": 0.3
                                },
                                "suggested-genome-changes": null
                            },
                            "score": 0.3,
                            "min": 0.3,
                            "max": 1.0,
                            "uncertain": false,
                            "rank": 5.0,
                            "missingInformation": false,
                            "debug": null
                        }
                    ]
                },
                "filter": {
                    "@type": "and",
                    "pass": true,
                    "and": [
                        {
                            "@type": "or",
                            "pass": true,
                            "or": [
                                {
                                    "@type": "concrete",
                                    "pass": false,
                                    "id": "proficiency",
                                    "input": {
                                        "criteria": {
                                            "skills": [
                                                {
                                                    "name": "Design systems",
                                                    "skillRef": null
                                                }
                                            ],
                                            "proficiencies": {
                                                "Design systems": "expert"
                                            },
                                            "experiences": [],
                                            "queryContext": "search",
                                            "skillsForMatching": null
                                        },
                                        "opportunity": {
                                            "skills": [
                                                {
                                                    "name": "Adobe XD"
                                                },
                                                {
                                                    "name": "Figma"
                                                },
                                                {
                                                    "name": "Product design"
                                                },
                                                {
                                                    "name": "Sketch"
                                                },
                                                {
                                                    "name": "Accessibility"
                                                },
                                                {
                                                    "name": "Fintech"
                                                },
                                                {
                                                    "name": "User-centered design"
                                                }
                                            ],
                                            "proficiencies": {
                                                "Adobe XD": "expert",
                                                "Figma": "expert",
                                                "Product design": "expert",
                                                "Sketch": "expert",
                                                "Accessibility": "proficient",
                                                "Fintech": "proficient",
                                                "User-centered design": "proficient"
                                            },
                                            "experiences": {},
                                            "skillMatchEvaluations": [
                                                {
                                                    "opportunitySkill": "Product design",
                                                    "skillMatchType": "exact-match",
                                                    "maxProficiency": "expert",
                                                    "maxRelevantProficiency": "expert",
                                                    "implicitMatch": false,
                                                    "matchingSkills": [
                                                        {
                                                            "skillName": "Product design",
                                                            "proficiency": "expert",
                                                            "relevantProficiency": "expert",
                                                            "implicitMatch": false
                                                        }
                                                    ]
                                                },
                                                {
                                                    "opportunitySkill": "Accessibility",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "Adobe XD",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "Figma",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "Fintech",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "Sketch",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "User-centered design",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                }
                                            ],
                                            "experienceEvaluations": []
                                        },
                                        "suggested-genome-changes": {
                                            "missing": [
                                                {
                                                    "code": 15431355,
                                                    "name": "Adobe XD",
                                                    "proficiency": "expert",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 62652,
                                                    "name": "Figma",
                                                    "proficiency": "expert",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 51976,
                                                    "name": "Sketch",
                                                    "proficiency": "expert",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": -2147483427,
                                                    "name": "Accessibility",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 682491,
                                                    "name": "Fintech",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 59906,
                                                    "name": "User-centered design",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                }
                                            ]
                                        }
                                    },
                                    "debug": null
                                },
                                {
                                    "@type": "concrete",
                                    "pass": true,
                                    "id": "role",
                                    "input": {
                                        "criteria": {
                                            "role": "Design systems"
                                        },
                                        "opportunity": {
                                            "role": "Lead Product Designer-Design Systems"
                                        },
                                        "suggested-genome-changes": null
                                    },
                                    "debug": null
                                }
                            ]
                        },
                        {
                            "@type": "concrete",
                            "pass": true,
                            "id": "keywords",
                            "input": {
                                "criteria": {
                                    "keywords": [
                                        "designer"
                                    ]
                                },
                                "opportunity": {},
                                "suggested-genome-changes": null
                            },
                            "debug": null
                        },
                        {
                            "@type": "concrete",
                            "pass": true,
                            "id": "language",
                            "input": {
                                "criteria": {
                                    "languages": {
                                        "en": "fully-fluent"
                                    }
                                },
                                "opportunity": {
                                    "languages": {
                                        "en": "conversational"
                                    }
                                },
                                "suggested-genome-changes": {
                                    "missing-language": null
                                }
                            },
                            "debug": null
                        },
                        {
                            "@type": "or",
                            "pass": true,
                            "or": [
                                {
                                    "@type": "concrete",
                                    "pass": false,
                                    "id": "proficiency",
                                    "input": {
                                        "criteria": {
                                            "skills": [
                                                {
                                                    "name": "Product design",
                                                    "skillRef": null
                                                }
                                            ],
                                            "proficiencies": {
                                                "Product design": "expert"
                                            },
                                            "experiences": [],
                                            "queryContext": "search",
                                            "skillsForMatching": null
                                        },
                                        "opportunity": {
                                            "skills": [
                                                {
                                                    "name": "Adobe XD"
                                                },
                                                {
                                                    "name": "Figma"
                                                },
                                                {
                                                    "name": "Product design"
                                                },
                                                {
                                                    "name": "Sketch"
                                                },
                                                {
                                                    "name": "Accessibility"
                                                },
                                                {
                                                    "name": "Fintech"
                                                },
                                                {
                                                    "name": "User-centered design"
                                                }
                                            ],
                                            "proficiencies": {
                                                "Adobe XD": "expert",
                                                "Figma": "expert",
                                                "Product design": "expert",
                                                "Sketch": "expert",
                                                "Accessibility": "proficient",
                                                "Fintech": "proficient",
                                                "User-centered design": "proficient"
                                            },
                                            "experiences": {},
                                            "skillMatchEvaluations": [
                                                {
                                                    "opportunitySkill": "Product design",
                                                    "skillMatchType": "exact-match",
                                                    "maxProficiency": "expert",
                                                    "maxRelevantProficiency": "expert",
                                                    "implicitMatch": false,
                                                    "matchingSkills": [
                                                        {
                                                            "skillName": "Product design",
                                                            "proficiency": "expert",
                                                            "relevantProficiency": "expert",
                                                            "implicitMatch": false
                                                        }
                                                    ]
                                                },
                                                {
                                                    "opportunitySkill": "Accessibility",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "Adobe XD",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "Figma",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "Fintech",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "Sketch",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                },
                                                {
                                                    "opportunitySkill": "User-centered design",
                                                    "skillMatchType": "missing-skill",
                                                    "maxProficiency": "no-experience-interested",
                                                    "maxRelevantProficiency": "no-experience-interested",
                                                    "implicitMatch": false,
                                                    "matchingSkills": []
                                                }
                                            ],
                                            "experienceEvaluations": []
                                        },
                                        "suggested-genome-changes": {
                                            "missing": [
                                                {
                                                    "code": 15431355,
                                                    "name": "Adobe XD",
                                                    "proficiency": "expert",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 62652,
                                                    "name": "Figma",
                                                    "proficiency": "expert",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 51976,
                                                    "name": "Sketch",
                                                    "proficiency": "expert",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": -2147483427,
                                                    "name": "Accessibility",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 682491,
                                                    "name": "Fintech",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                },
                                                {
                                                    "code": 59906,
                                                    "name": "User-centered design",
                                                    "proficiency": "proficient",
                                                    "implicitlyMatched": false
                                                }
                                            ]
                                        }
                                    },
                                    "debug": null
                                },
                                {
                                    "@type": "concrete",
                                    "pass": true,
                                    "id": "role",
                                    "input": {
                                        "criteria": {
                                            "role": "Product design"
                                        },
                                        "opportunity": {
                                            "role": "Lead Product Designer-Design Systems"
                                        },
                                        "suggested-genome-changes": null
                                    },
                                    "debug": null
                                }
                            ]
                        },
                        {
                            "@type": "concrete",
                            "pass": true,
                            "id": "status",
                            "input": {
                                "criteria": {
                                    "status": "open"
                                },
                                "opportunity": {
                                    "status": "open"
                                },
                                "suggested-genome-changes": null
                            },
                            "debug": null
                        }
                    ]
                },
                "boosters": [
                    "native",
                    "reach"
                ]
            },
            "videoUrl": null,
            "serviceTypes": [
                "essential"
            ],
            "quickApply": true
        }
    ],
    "aggregators": {},
    "offset": 0,
    "pagination": {
        "previous": null,
        "next": "eyJjcmVhdGVkIjoiMjAyNS0xMS0xMFQyMDo0NTo1Mi4wMDBaIiwic3RhdHVzIjoib3BlbiIsInJhbmtWYWx1ZSI6MC45NzI3Mzc0MDg2ODg5NjU5LCJtYXRjaFNjb3JlIjowLjk4NjI3NDUwOTgwMzkyMTYsIm1heFNlcnZpY2VUeXBlIjoiZXNzZW50aWFsIn0="
    }
}
```

Keywords in the request body can be replaced with the technology tags selected by the user. The API will return job listings that match the specified criteria.
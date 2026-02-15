import { Route } from "simple-react-routing";
import HomePage from "./pages/HomePage";
import TagSelectionPage from "./pages/TagSelectionPage";
import QuestionaryPage from "./pages/QuestionaryPage";
import ResultsPage from "./pages/ResultsPage";
import JobsByKnowledgePage from "./pages/JobsByKnowledgePage";
import BrowseJobsPage from "./pages/BrowseJobsPage";

export const routes: Route[] = [
  {
    component: <HomePage />,
    path: "/",
    name: "home",
  },
  {
    component: <TagSelectionPage />,
    path: "/assessment",
    name: "assessment",
  },
  {
    component: <QuestionaryPage />,
    path: "/questionary/:id",
    name: "questionary",
  },
  {
    component: <ResultsPage />,
    path: "/results/:id",
    name: "results",
  },
  {
    component: <JobsByKnowledgePage />,
    path: "/jobs/knowledge/:id",
    name: "jobs-by-knowledge",
    priority: 1,
  },
  {
    component: <BrowseJobsPage />,
    path: "/jobs",
    name: "browse-jobs",
  },
];
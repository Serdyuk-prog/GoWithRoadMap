
const API_BASE_URL = 'http://localhost/api/v1';

async function searchRoadmaps(search) {
  const url = new URL(API_BASE_URL);
  if (search) {
    url.searchParams.set('search', search);
  }
  const res = await fetch(url);
  const data = await res.json();
  return data;
}

async function createRoadmap(roadmap) {
  const url = `${API_BASE_URL}/roadmaps`;
  const options = {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(roadmap)
  };
  const response = await fetch(url, options);
  const data = await response.json();
  return data;
}

async function getRoadmapById(id) {
  const url = `${API_BASE_URL}/roadmaps/${id}`;
  const response = await fetch(url);
  if (!response.ok) {
    throw new Error('Roadmap not found');
  }
  const data = await response.json();
  return data;
}

async function updateRoadmap(id, roadmap) {
  const url = `${API_BASE_URL}/roadmaps/${id}`;
  const options = {
    method: 'PATCH',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(roadmap)
  };
  const response = await fetch(url, options);
  if (!response.ok) {
    throw new Error('Roadmap not found');
  }
  return true;
}

module.exports = {
  searchRoadmaps,
  createRoadmap,
  getRoadmapById,
  updateRoadmap,
};
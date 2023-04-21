const API_BASE_URL = 'http://localhost/api/v1';

async function getHistory(briefly = false) {
  const url = new URL(API_BASE_URL);
  url.searchParams.set('briefly', briefly);
  const res = await fetch(url);
  const data = await res.json();
  return data;
}

module.exports = {getHistory}
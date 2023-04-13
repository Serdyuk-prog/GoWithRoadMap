
export function transformJson(json) {
  const { map, titles, desc, kind, status } = json;

  const content = titles.map((title, index) => ({
    id: index, // в джсоне нужен id
    title,
    description: desc[index],
    kind: kind[index] || 'optional', 
    status: status[index] || 'proposed', 
  }));

  return {
    title: map.title,
    description: map.description,
    content,
  };
}
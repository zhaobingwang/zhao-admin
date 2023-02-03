import service from '@/axios';

export function getSample(id: string) {
  return service.get(`/sample/${id}`);
}

export function createSample(data: any) {
  return service.post('/sample', data);
}

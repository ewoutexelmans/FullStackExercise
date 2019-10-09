import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';

export function invokeRequest<T>(
  httpRequest: Observable<T>,
  callback: (result: T) => void
) {
  httpRequest.pipe(take(1)).subscribe(callback);
}

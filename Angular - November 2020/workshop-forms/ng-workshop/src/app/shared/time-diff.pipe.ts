import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'timeDiff'
})
export class TimeDiffPipe implements PipeTransform {

  transform(value: string): string {
    const locale = 'en';
    const msPerMinute = 60 * 1000;
    const msPerHour = msPerMinute * 60;
    const msPerDay = msPerHour * 24;
    const msPerMonth = msPerDay * 30;
    const msPerYear = msPerMonth * 365;

    const valueDate = new Date(value);
    const current = new Date();
    const elapsed = +current - +valueDate;

    const rtf = new Intl.RelativeTimeFormat(locale, { numeric: 'auto' });

    if (elapsed < msPerMinute) {
      return rtf.format(-Math.floor(elapsed / 1000), 'seconds');
    }
    if (elapsed < msPerHour) {
      return rtf.format(-Math.floor(elapsed / msPerMinute), 'minutes');
    }
    if (elapsed < msPerDay) {
      return rtf.format(-Math.floor(elapsed / msPerHour), 'hours');
    }
    if (elapsed < msPerMonth) {
      return rtf.format(-Math.floor(elapsed / msPerDay), 'days');
    }
    if (elapsed < msPerYear) {
      return rtf.format(-Math.floor(elapsed / msPerMonth), 'months');
    }

    return null;
  }

}
